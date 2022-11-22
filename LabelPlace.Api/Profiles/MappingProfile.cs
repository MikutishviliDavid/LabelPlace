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
            CreateMap<CreateCompanyRequest, CreateCompanyDtoRequest>();
            CreateMap<CreateCompanyDtoResponse, CreateCompanyResponse>();
            CreateMap<GetCompanyDtoResponse, GetCompanyResponse>();
            CreateMap<UpdateCompanyRequest, UpdateCompanyDto>();
            CreateMap<CreateCompanyDtoResponse, GetCompanyResponse>();
            CreateMap<LoginViewModel, LoginDto>();
            CreateMap<RegisterViewModel, RegisterDto>();
        }
    }
}
