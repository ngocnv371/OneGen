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
		public virtual GenerationStatus Status { get; internal set; }

		[StringLength(OneGenConsts.MaxNameLength)]
		public virtual string ObjectType { get; protected set; }

		public virtual Guid ObjectId { get; protected set; }

		[StringLength(OneGenConsts.MaxNameLength)]
		public virtual string Operation { get; protected set; }

		[StringLength(OneGenConsts.MaxNameLength)]
		public virtual string Prompt { get; protected set; }

		protected Subject()
		{ }

		public Subject(Guid id, SubjectType type, string objectType, Guid objectId, string operation, string prompt)
		{
			Id = id;
			Type = type;
			ObjectType = objectType;
			ObjectId = objectId;
			Operation = operation;
			Prompt = prompt;
			Status = GenerationStatus.Pending;
		}
	}
}