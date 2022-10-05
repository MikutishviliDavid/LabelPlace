using AutoMapper;
using LabelPlace.Api.ViewModels;
using LabelPlace.BusinessLogic.Dto;
using LabelPlace.BusinessLogic.Profiles;

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
