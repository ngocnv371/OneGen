using System;

namespace OneGen.Generation
{
	public class CreateSubjectDto
	{
		public virtual SubjectType Type { get; set; }

		public virtual string ObjectType { get; set; }

		public virtual Guid ObjectId { get; set; }

		public virtual string Operation { get; set; }

		public virtual string Prompt { get; set; }
	}
}