using AutoMapper;
using OneGen.Generation;

namespace OneGen;

public class VariantsAutoMapperProfile : Profile
{
	public VariantsAutoMapperProfile()
	{
		CreateMap<Variant, VariantDto>();
	}
}