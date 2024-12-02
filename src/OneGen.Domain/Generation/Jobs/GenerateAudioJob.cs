using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using T = System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using OneGen.Generation;
using System.Text.Json.Serialization;
using System;

namespace OneGen.Generation.Jobs
{
	public class GenerateAudioArgs(Guid? tenantId, Guid? taskId) : IMultiTenant
	{
		public Guid? TenantId { get; } = tenantId;
		public Guid? TaskId { get; } = taskId;
	}

	internal class SunoOutput
	{
		public string Audio_Out { get; set; }
	}

	internal class SunoResponse
	{
		public SunoOutput Output { get; set; }

		public string Started_At { get; set; }

		public string Completed_At { get; set; }

		public string Status { get; set; }
	}

	public class GenerateAudioJob(
			IRepository<Task> repository,
			IRepository<Subject> subjectsRepository,
			HttpClient httpClient,
			IConfiguration configuration,
			ICurrentTenant currentTenant
			)
		: AsyncBackgroundJob<GenerateAudioArgs>,
		ITransientDependency
	{
		public override async T.Task ExecuteAsync(GenerateAudioArgs args)
		{
			Logger.LogInformation("Generate audio task {taskId}", args.TaskId);
			using (currentTenant.Change(args.TenantId))
			{
				var item = await repository.GetAsync(r => r.Id == args.TaskId);
				var subject = await subjectsRepository.GetAsync(r => r.Id == item.SubjectId);
				item.SetStarted();
				await repository.UpdateAsync(item, true);

				try
				{
					var result = await Generate(subject, item);
					item.SetCompleted(subject, [result]);
					await repository.UpdateAsync(item, true);
				}
				catch (Exception)
				{
					item.SetFailed();
					await repository.UpdateAsync(item, true);
					throw;
				}
			}
		}

		private async T.Task<string> Generate(Subject subject, Task task)
		{
			var api = configuration["SunoBark:ApiUrl"];
			var url = $"{api}/predictions";

			var payload = new
			{
				input = new
				{
					prompt = subject.Prompt,
					history_prompt = "announcer",
					text_temp = 0.7,
					waveform_temp = 0.7,
					output_full = true
				},
			};

			var json = JsonSerializer.Serialize(payload);
			Logger.LogInformation("[AudioGen] payload: {json}", json);

			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var result = await httpClient.PostAsync(url, content);
			var text = await result.Content.ReadAsStringAsync();
			var data = JsonSerializer.Deserialize<SunoResponse>(text, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			var output = data.Output.Audio_Out;
			var stripedPrefix = output.Split(",")[1];
			return stripedPrefix;
		}
	}
}