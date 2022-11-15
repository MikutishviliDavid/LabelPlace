using AutoMapper;
using LabelPlace.Api.ViewModels.CompanyViewModels;
using LabelPlace.Api.ViewModels.UserViewModels;
using LabelPlace.BusinessLogic.Dto.CompanyDtos;
using LabelPlace.BusinessLogic.Dto.UserDtos;
using LabelPlace.BusinessLogic.Profiles;

namespace LabelPlace.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyRequest, CreateCompanyDtoRequest>().ReverseMap();
            CreateMap<CreateCompanyResponse, CreateCompanyDtoResponse>().ReverseMap();
            CreateMap<UpdateCompanyRequest, UpdateCompanyDto>().ReverseMap();
            CreateMap<GetCompanyResponse, CreateCompanyDtoResponse>().ReverseMap();
            CreateMap<LoginViewModel, LoginDto>().ReverseMap();
            CreateMap<RegisterViewModel, RegisterDto>().ReverseMap();
        }
    }
}
