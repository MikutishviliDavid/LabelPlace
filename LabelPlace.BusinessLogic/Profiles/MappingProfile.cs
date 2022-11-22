using AutoMapper;
using LabelPlace.BusinessLogic.Dto;
using LabelPlace.BusinessLogic.Dto.CompanyDtos;
using LabelPlace.BusinessLogic.Dto.UserDtos;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyDtoRequest, Company>().ReverseMap();
            CreateMap<Company, CreateCompanyDtoResponse>().ReverseMap();
            CreateMap<Company, GetCompanyDtoResponse>();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
        }
    }
}
