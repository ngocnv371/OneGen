using System;
using Volo.Abp.Application.Dtos;

namespace OneGen.Generation
{
	public class SubjectDto : CreationAuditedEntityDto<Guid>
	{
		public virtual Guid? TenantId { get; set; }
		public virtual SubjectType Type { get; set; }
		public virtual GenerationStatus Status { get; internal set; }

		public virtual string ObjectType { get; set; }

		public virtual Guid ObjectId { get; set; }

		public virtual string Operation { get; set; }

		public virtual string Prompt { get; set; }
	}
}