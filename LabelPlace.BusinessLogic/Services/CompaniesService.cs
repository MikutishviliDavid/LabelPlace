using AutoMapper;
using LabelPlace.BusinessLogic.CustomExceptions;
using LabelPlace.BusinessLogic.Dto.CompanyDtos;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Dal.UnitOfWork;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services
{
    public class CompaniesService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetCompanyDtoResponse>> GetAllAsync()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync();

            return _mapper.Map<IEnumerable<GetCompanyDtoResponse>>(companies);
        }

        public async Task<IEnumerable<GetCompanyDtoResponse>> GetAllByCountryAsync(string country)
        {
            /*if (!country.HasValue)
                return BadRequest();*/
            var companies = await _unitOfWork.Companies.GetAllByCountryAsync(country);

            return _mapper.Map<IEnumerable<GetCompanyDtoResponse>>(companies);
        }

        public async Task<GetCompanyDtoResponse> GetByIdAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);

            if (company == null)
            {
                throw new BusinessLogicNotFoundException($"Company with Id: {id} not found.");
            }

            return _mapper.Map<GetCompanyDtoResponse>(company);
        }

        public async Task<CreateCompanyDtoResponse> InsertAsync(CreateCompanyDtoRequest request)
        {
            var company = _mapper.Map<Company>(request);

            await _unitOfWork.Companies.InsertAsync(company);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CreateCompanyDtoResponse>(company);
        }

        public async Task UpdateAsync(int id, UpdateCompanyDto request)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);

            if (company == null)
            {
                throw new BusinessLogicNotFoundException($"Company with Id: {id} not found.");
            }
            
            var updatedCompany = _mapper.Map<Company>(request);

            updatedCompany.Id = id;

            _unitOfWork.Companies.Update(updatedCompany);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);

            if (company == null)
            {
                throw new BusinessLogicNotFoundException($"Company with Id: {id} not found.");
            }

            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.SaveAsync();
        }  
    }
}
