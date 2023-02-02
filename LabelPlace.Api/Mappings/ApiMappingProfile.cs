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

            CreateMap<UpdateCompanyRequest, UpdateCompanyDtoRequest>();

            CreateMap<CreateCompanyDtoResponse, GetCompanyResponse>();

            CreateMap<LoginUserRequest, LoginUserDtoRequest>();

            CreateMap<RegisterUserRequest, RegisterUserDtoRequest>();

            CreateMap<LoginUserDtoResponse, GetUserResponse>();

            CreateMap<RegisterUserDtoResponse, RegisterUserResponse>();
        }
    }
}
