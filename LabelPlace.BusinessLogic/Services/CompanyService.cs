using AutoMapper;
using LabelPlace.BusinessLogic.CustomExceptions;
using LabelPlace.BusinessLogic.Dtos.CompanyDtos;
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

        public async Task<IEnumerable<GetCompanyDtoResponse>> GetAllAsync()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync();

            return _mapper.Map<IEnumerable<GetCompanyDtoResponse>>(companies);
        }

        public async Task<IEnumerable<GetCompanyDtoResponse>> GetAllByCountryAsync(string country)
        {
            var companies = await _unitOfWork.Companies.GetAllByCountryAsync(country);

            return _mapper.Map<IEnumerable<GetCompanyDtoResponse>>(companies);
        }

        public async Task<GetCompanyDtoResponse> GetByIdAsync(int id)
        {
            var company = await GetCompanyByIdAsync(id);

            return _mapper.Map<GetCompanyDtoResponse>(company);
        }

        public async Task<CreateCompanyDtoResponse> InsertAsync(CreateCompanyDtoRequest request)
        {
            var companyByName = await _unitOfWork.Companies.GetByNameAsync(request.Name);

            if (companyByName != null)
            {
                throw new BusinessLogicAlreadyExistsException($"Company with name: {request.Name} already exists.");
            }

            var company = _mapper.Map<Company>(request);

            await _unitOfWork.Companies.InsertAsync(company);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<CreateCompanyDtoResponse>(company);
        }

        public async Task UpdateAsync(int id, UpdateCompanyDtoRequest request)
        {
            var company = await GetCompanyByIdAsync(id);

            company = _mapper.Map(request, company);

            _unitOfWork.Companies.Update(company);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetCompanyByIdAsync(id);

            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.SaveAsync();
        }

        private async Task<Company> GetCompanyByIdAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);

            if (company == null)
            {
                throw new BusinessLogicNotFoundException($"Company with Id: {id} not found.");
            }

            return company;
        }
    }
}
