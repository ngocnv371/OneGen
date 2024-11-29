using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using T = System.Threading.Tasks;

namespace OneGen.Generation.EventHandlers
{
	internal class TaskCreatedEventHandler(
		GenerationManager generationManager
		)
		: ILocalEventHandler<EntityCreatedEventData<Task>>, ITransientDependency
	{
		public async T.Task HandleEventAsync(EntityCreatedEventData<Task> eventData)
		{
			await generationManager.ScheduleJob(eventData.Entity);
		}
	}
}