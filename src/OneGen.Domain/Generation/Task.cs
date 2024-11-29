using OneGen.Generation.Events;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace OneGen.Generation
{
	public class Task : AuditedAggregateRoot<Guid>, IMultiTenant
	{
		public virtual Guid? TenantId { get; protected set; }
		public virtual Guid SubjectId { get; protected set; }
		public virtual GenerationStatus Status { get; protected set; }

		protected Task()
		{ }

		public Task(Guid id, Guid subjectId)
		{
			Id = id;
			SubjectId = subjectId;
			Status = GenerationStatus.Pending;
		}

		public Task SetStarted()
		{
			Status = GenerationStatus.Processing;
			AddLocalEvent(new TaskStartedEvent(this));
			return this;
		}

		public Task SetFailed()
		{
			Status = GenerationStatus.Failed;
			AddLocalEvent(new TaskFailedEvent(this));
			return this;
		}

		public Task SetCompleted(string[] value)
		{
			Status = GenerationStatus.Completed;
			AddLocalEvent(new TaskCompletedEvent(this, value));
			return this;
		}
	}
}