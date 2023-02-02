using AutoMapper;
using LabelPlace.BusinessLogic.Dtos;
using LabelPlace.BusinessLogic.Dtos.CompanyDtos;
using LabelPlace.BusinessLogic.Dtos.UserDtos;
using LabelPlace.Domain.Entities;

namespace LabelPlace.BusinessLogic.Mappings
{
    public class BusinessLogicMappingProfile : Profile
    {
        public BusinessLogicMappingProfile()
        {
            CreateMap<CreateCompanyDtoRequest, Company>();

            CreateMap<Company, GetCompanyDtoResponse>();

            CreateMap<CreateCompanyDtoResponse, Company>()
                .ReverseMap();

            CreateMap<Company, UpdateCompanyDtoRequest>()
                .ReverseMap();

            CreateMap<NewUserDto, User>();

            CreateMap<User, LoginUserDtoResponse>();

            CreateMap<User, RegisterUserDtoResponse>();
        }
    }
}
