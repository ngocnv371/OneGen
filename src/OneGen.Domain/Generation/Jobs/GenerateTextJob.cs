using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using T = System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace OneGen.Generation.Jobs
{
	public class GenerateTextArgs(Guid? tenantId, Guid? taskId) : IMultiTenant
	{
		public Guid? TenantId { get; } = tenantId;
		public Guid? TaskId { get; } = taskId;
	}

	public class GenerateTextJob(
			IRepository<Task> repository,
			IRepository<Subject> subjectsRepository,
			IConfiguration configuration,
			ICurrentTenant currentTenant
			)
		: AsyncBackgroundJob<GenerateTextArgs>,
		ITransientDependency
	{
		public override async T.Task ExecuteAsync(GenerateTextArgs args)
		{
			Logger.LogInformation("Execute generative task {taskId}", args.TaskId);
			using (currentTenant.Change(args.TenantId))
			{
				var item = await repository.GetAsync(r => r.Id == args.TaskId);
				var subject = await subjectsRepository.GetAsync(r => r.Id == item.SubjectId);
				item.SetStarted();
				await repository.UpdateAsync(item, true);

				try
				{
					var result = await Generate(subject, item);
					item.SetCompleted([result]);
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
			var url = configuration["OpenAI:ApiUrl"];
			var key = configuration["OpenAI:ApiKey"];
			var model = configuration["OpenAI:Model"];

			var api = new OpenAI.OpenAIClient(new System.ClientModel.ApiKeyCredential(key), new OpenAI.OpenAIClientOptions
			{
				Endpoint = new Uri(url),
			});

			var client = api.GetChatClient(model);
			var message = new OpenAI.Chat.UserChatMessage(subject.Prompt);
			// one shot
			var result = await client.CompleteChatAsync(message);
			if (result.Value.Id.IsNullOrEmpty())
			{
				throw new Exception("OpenAI request failed");
			}

			var text = result.Value.Content[0].Text;
			return text;
		}
	}
}