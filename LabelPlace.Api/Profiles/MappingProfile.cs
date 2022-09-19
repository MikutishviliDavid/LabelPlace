using AutoMapper;
using LabelPlace.Api.ViewModels;
using LabelPlace.BusinessLogic.Dto;

namespace LabelPlace.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyViewModel, CompanyDto>().ReverseMap();
        }
    }
}
