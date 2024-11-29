using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using T = System.Threading.Tasks;

namespace OneGen.Generation.EventHandlers
{
	internal class SubjectCreatedEventHandler(
		GenerationManager generationManager
		)
		: ILocalEventHandler<EntityCreatedEventData<Subject>>, ITransientDependency
	{
		public async T.Task HandleEventAsync(EntityCreatedEventData<Subject> eventData)
		{
			await generationManager.CreateTask(eventData.Entity);
		}
	}
}