using OneGen.Generation.Events;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using T = System.Threading.Tasks;

namespace OneGen.Generation.EventHandlers
{
	public class TaskFailedEventHandler(
		GenerationManager generationManager
		)
		: ILocalEventHandler<TaskFailedEvent>, ITransientDependency
	{
		public async T.Task HandleEventAsync(TaskFailedEvent eventData)
		{
			await generationManager.UpdateSubjectStatus(eventData.Task);
		}
	}
}