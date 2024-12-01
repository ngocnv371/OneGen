using System;
using Volo.Abp.Application.Dtos;

namespace OneGen.Generation
{
	public class VariantQueryDto : PagedAndSortedResultRequestDto
	{
		public Guid SubjectId { get; set; }
	}
}