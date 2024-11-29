using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace OneGen.Generation
{
	public class Variant : CreationAuditedEntity<Guid>, IMultiTenant
	{
		public virtual Guid? TenantId { get; protected set; }
		public virtual Guid? SubjectId { get; protected set; }
		public virtual Guid? TaskId { get; protected set; }
		public virtual string Value { get; protected set; }
	}
}