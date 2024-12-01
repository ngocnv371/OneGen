using AutoMapper;
using OneGen.Generation;

namespace OneGen;

public class SubjectsAutoMapperProfile : Profile
{
	public SubjectsAutoMapperProfile()
	{
		CreateMap<CreateSubjectDto, Subject>();
		CreateMap<Subject, SubjectDto>();
	}
}