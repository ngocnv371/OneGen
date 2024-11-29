using System;
using Volo.Abp.Application.Dtos;

namespace OneGen.Generation
{
	public class VariantDto : CreationAuditedEntityDto<Guid>
	{
		public virtual Guid? TenantId { get; set; }
		public virtual Guid TaskId { get; set; }
		public virtual string Value { get; set; }
	}
}