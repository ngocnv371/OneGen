using System;
using Volo.Abp.Application.Services;

namespace OneGen.Generation
{
	public interface IVariantsAppService
		: ICrudAppService<VariantDto, Guid, VariantQueryDto>
	{
	}
}