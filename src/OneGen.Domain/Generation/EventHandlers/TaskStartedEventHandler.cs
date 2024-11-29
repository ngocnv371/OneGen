using OneGen.Generation.Events;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using T = System.Threading.Tasks;

namespace OneGen.Generation.EventHandlers
{
	public class TaskStartedEventHandler(
		GenerationManager generationManager
		)
		: ILocalEventHandler<TaskStartedEvent>, ITransientDependency
	{
		public async T.Task HandleEventAsync(TaskStartedEvent eventData)
		{
			await generationManager.UpdateSubjectStatus(eventData.Task);
		}
	}
}