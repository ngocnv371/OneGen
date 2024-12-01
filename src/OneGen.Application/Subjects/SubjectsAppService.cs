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
		public SubjectsAppService(IRepository<Subject, Guid> repository)
			: base(repository)
		{
			LocalizationResource = typeof(OneGenResource);
		}
	}
}