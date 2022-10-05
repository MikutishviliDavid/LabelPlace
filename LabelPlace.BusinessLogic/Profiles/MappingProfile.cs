using AutoMapper;
using LabelPlace.BusinessLogic.Dto;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyDto, Company>().ReverseMap();
        }
    }
}
