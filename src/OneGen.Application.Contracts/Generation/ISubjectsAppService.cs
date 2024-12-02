using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OneGen.Generation
{
	public interface ISubjectsAppService
		: ICrudAppService<SubjectDto, Guid, PagedAndSortedResultRequestDto, CreateSubjectDto>
	{
		Task RegenerateAsync(Guid id);
	}
}