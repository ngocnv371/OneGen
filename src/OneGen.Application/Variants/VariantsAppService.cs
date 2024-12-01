using OneGen.Generation;
using OneGen.Localization;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OneGen.Variants
{
	public class VariantsAppService
		: CrudAppService<Variant, VariantDto, Guid, VariantQueryDto>,
		IVariantsAppService
	{
		public VariantsAppService(IRepository<Variant, Guid> repository)
			: base(repository)
		{
			LocalizationResource = typeof(OneGenResource);
		}
	}
}