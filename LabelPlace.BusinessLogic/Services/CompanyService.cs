using AutoMapper;
using LabelPlace.BusinessLogic.CustomExceptions;
using LabelPlace.BusinessLogic.Dto;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Dal.UnitOfWork;
using LabelPlace.Domain.Entities;
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

            if (companies.Count == 0)
            {
                throw new BusinessLogicNotFoundException($"Сompanies have not been added yet");
            }

            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public async Task<CompanyDto> GetByIdAsync(int id)
        {
            var company = await _unitOfWork.Company.GetByIdAsync(id);

            if (company == null)
            {
                throw new BusinessLogicNotFoundException($"Company with Id: {id} not found.");
            }

            return _mapper.Map<CompanyDto>(company);
        }

        public async Task<CompanyDto> InsertAsync(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);

            await _unitOfWork.Company.InsertAsync(company);
            await _unitOfWork.SaveAsync();

            return companyDto;
        }

        public async Task Update(int id, CompanyDto companyDto)
        {
            var company = await _unitOfWork.Company.GetByIdAsync(id);

            if (company == null)
            {
                throw new BusinessLogicNotFoundException($"Company with Id: {id} not found.");
            }
            
            var forUpdateCompany = _mapper.Map<Company>(companyDto);

            _unitOfWork.Company.Update(forUpdateCompany);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _unitOfWork.Company.GetByIdAsync(id);

            if (company == null)
            {
                throw new BusinessLogicNotFoundException($"Company with Id: {id} not found.");
            }

            _unitOfWork.Company.Delete(company);
            await _unitOfWork.SaveAsync();
        }  
    }
}
