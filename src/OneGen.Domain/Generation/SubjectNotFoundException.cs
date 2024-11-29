using System;
using Volo.Abp;

namespace OneGen.Generation
{
	internal class SubjectNotFoundException(Guid id)
		: BusinessException(message: "Subject not found", details: id.ToString())
	{
	}
}