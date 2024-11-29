using OneGen.Generation.Events;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;
using T = System.Threading.Tasks;

namespace OneGen.Generation.EventHandlers
{
	public class TaskCompletedEventHandler(
		GenerationManager generationManager
		)
		: ILocalEventHandler<TaskCompletedEvent>, ITransientDependency
	{
		[UnitOfWork]
		public async T.Task HandleEventAsync(TaskCompletedEvent eventData)
		{
			await generationManager.UpdateSubjectStatus(eventData.Task);
			await generationManager.CreateVariant(eventData.Task, eventData.Value);
		}
	}
}