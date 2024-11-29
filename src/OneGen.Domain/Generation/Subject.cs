using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace OneGen.Generation
{
	public class Subject : AggregateRoot<Guid>, IMultiTenant
	{
		public virtual Guid? TenantId { get; protected set; }
		public virtual SubjectType Type { get; protected set; }
		public virtual GenerationStatus Status { get; protected set; }

		[StringLength(OneGenConsts.MaxNameLength)]
		public virtual string ObjectType { get; protected set; }

		public virtual Guid ObjectId { get; protected set; }

		[StringLength(OneGenConsts.MaxNameLength)]
		public virtual string Operation { get; protected set; }

		[StringLength(OneGenConsts.MaxNameLength)]
		public virtual string Prompt { get; protected set; }
	}
}