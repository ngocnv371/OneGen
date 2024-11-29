using System;
using Volo.Abp.Application.Dtos;

namespace OneGen.Generation
{
	public class TaskDto : CreationAuditedEntityDto<Guid>
	{
		public virtual Guid? TenantId { get; set; }
		public virtual Guid SubjectId { get; set; }
		public virtual GenerationStatus Status { get; set; }
	}
}