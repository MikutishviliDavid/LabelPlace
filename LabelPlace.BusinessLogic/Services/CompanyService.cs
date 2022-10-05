using AutoMapper;
using LabelPlace.BusinessLogic.Dto;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Dal.UnitOfWork;
using LabelPlace.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var companies = await _unitOfWork.Company.GetAllAsync();

            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public async Task<CompanyDto> GetAsync(int id)
        {
            var company = await _unitOfWork.Company.GetAsync(id);

            return _mapper.Map<CompanyDto>(company);
        }

        public async Task<CompanyDto> InsertAsync(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);

            await _unitOfWork.Company.InsertAsync(company);
            await _unitOfWork.SaveAsync();

            return companyDto;
        }

        public async Task Update(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);

            _unitOfWork.Company.Update(company);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = _unitOfWork.Company.Find(id); // GetById

            if (company == null)
            {
                throw new Exception($"Company with Id: {id} not found.");
                
            }

            _unitOfWork.Company.Delete(company);
            await _unitOfWork.SaveAsync();
        }  
    }
}
