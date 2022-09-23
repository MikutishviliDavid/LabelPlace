using AutoMapper;
using LabelPlace.BusinessLogic.Dto;
using LabelPlace.Domain.Entities;

namespace LabelPlace.BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        MappingProfile()
        {
            CreateMap<CompanyDto, Company>();
        }
    }
}
