using System;
using Volo.Abp;

namespace OneGen.Generation
{
	public class SubjectNotFoundException(Guid id)
		: BusinessException(message: "Subject not found", details: id.ToString())
	{
	}
}