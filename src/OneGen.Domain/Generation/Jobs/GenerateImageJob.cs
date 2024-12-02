using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using T = System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OneGen.Generation.Jobs
{
	public class GenerateImageArgs(Guid? tenantId, Guid? taskId) : IMultiTenant
	{
		public Guid? TenantId { get; } = tenantId;
		public Guid? TaskId { get; } = taskId;
	}

	internal class SDResponse
	{
		public string[] Images { get; set; }
	}

	public class GenerateImageJob(
			IRepository<Task> repository,
			IRepository<Subject> subjectsRepository,
			HttpClient httpClient,
			IConfiguration configuration,
			ICurrentTenant currentTenant
			)
		: AsyncBackgroundJob<GenerateImageArgs>,
		ITransientDependency
	{
		public override async T.Task ExecuteAsync(GenerateImageArgs args)
		{
			Logger.LogInformation("Generate image task {taskId}", args.TaskId);
			using (currentTenant.Change(args.TenantId))
			{
				var item = await repository.GetAsync(r => r.Id == args.TaskId);
				var subject = await subjectsRepository.GetAsync(r => r.Id == item.SubjectId);
				item.SetStarted();
				await repository.UpdateAsync(item, true);

				try
				{
					var result = await Generate(subject, item);
					item.SetCompleted(subject, result);
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

		private async T.Task<string[]> Generate(Subject subject, Task task)
		{
			var api = configuration["StableDiffusion:ApiUrl"];
			var url = $"{api}/sdapi/v1/txt2img";

			var props = task.ExtraProperties;
			props["prompt"] = subject.Prompt;
			props["send_images"] = true;
			var json = JsonSerializer.Serialize(props);
			Logger.LogInformation("[ImageGen] payload: {json}", json);

			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var result = await httpClient.PostAsync(url, content);
			var text = await result.Content.ReadAsStringAsync();
			var data = JsonSerializer.Deserialize<SDResponse>(text, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			return data.Images;
		}
	}
}