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

		public Task SetStatus(GenerationStatus status)
		{
			switch (status)
			{
				case GenerationStatus.Processing:
					AddLocalEvent(new TaskStartedEvent(this));
					break;

				case GenerationStatus.Completed:
					AddLocalEvent(new TaskCompletedEvent(this));
					break;

				case GenerationStatus.Failed:
					AddLocalEvent(new TaskFailedEvent(this));
					break;
			}

			Status = status;
			return this;
		}
	}
}