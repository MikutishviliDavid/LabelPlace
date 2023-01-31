using AutoMapper;
using LabelPlace.Api.Models.CompanyModels;
using LabelPlace.Api.Models.RoleModels;
using LabelPlace.Api.Models.UserModels;
using LabelPlace.BusinessLogic.Dtos;
using LabelPlace.BusinessLogic.Dtos.CompanyDtos;
using LabelPlace.BusinessLogic.Dtos.UserDtos;

namespace LabelPlace.Api.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<CreateCompanyRequest, CreateCompanyDtoRequest>();

            CreateMap<CreateCompanyDtoResponse, CreateCompanyResponse>();

            CreateMap<GetCompanyDtoResponse, GetCompanyResponse>();

            CreateMap<UpdateCompanyRequest, UpdateCompanyDto>();

            CreateMap<CreateCompanyDtoResponse, GetCompanyResponse>();

            CreateMap<LoginUserRequest, LoginDto>();

            CreateMap<RegisterUserRequest, RegisterDto>();

            CreateMap<UserDtoResponse, UserResponse>();
        }
    }
}
