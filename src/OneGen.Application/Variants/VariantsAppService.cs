using OneGen.Generation;
using OneGen.Localization;
using System;
using System.Linq;
using T = System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OneGen.Variants
{
	public class VariantsAppService
		: CrudAppService<Variant, VariantDto, Guid, VariantQueryDto>,
		IVariantsAppService
	{
		private readonly IRepository<Task, Guid> _taskRepository;

		public VariantsAppService(
			IRepository<Variant, Guid> repository,
			IRepository<Task, Guid> taskRepository
			)
			: base(repository)
		{
			LocalizationResource = typeof(OneGenResource);

			_taskRepository = taskRepository;
		}

		protected override async T.Task<IQueryable<Variant>> CreateFilteredQueryAsync(VariantQueryDto input)
		{
			var variants = await Repository.GetQueryableAsync();
			var tasks = await _taskRepository.GetQueryableAsync();

			var query = from v in variants
						join t in tasks on v.TaskId equals t.Id
						where t.SubjectId == input.SubjectId
						select v;
			return query;
		}
	}
}