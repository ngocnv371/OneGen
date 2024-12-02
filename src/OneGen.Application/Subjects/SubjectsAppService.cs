using OneGen.Generation;
using OneGen.Localization;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OneGen.Subjects
{
	public class SubjectsAppService
		: CrudAppService<Subject, SubjectDto, Guid, PagedAndSortedResultRequestDto, CreateSubjectDto>,
		ISubjectsAppService
	{
		private readonly GenerationManager _generationManager;

		public SubjectsAppService(
			IRepository<Subject, Guid> repository,
			GenerationManager generationManager
			)
			: base(repository)
		{
			LocalizationResource = typeof(OneGenResource);

			_generationManager = generationManager;
		}

		public System.Threading.Tasks.Task RegenerateAsync(Guid id)
		{
			return _generationManager.RegenerateAsync(id);
		}
	}
}