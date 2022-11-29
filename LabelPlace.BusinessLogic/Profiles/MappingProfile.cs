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
            CreateMap<CreateCompanyDtoRequest, Company>().ReverseMap();// todo: deleete an unused ReverseMap

            CreateMap<Company, GetCompanyDtoResponse>().ReverseMap();//

            CreateMap<CreateCompanyDtoResponse, Company>().ReverseMap();//

            CreateMap<Company, UpdateCompanyDto>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<RoleDto, Role>().ReverseMap();
        }
    }
}
