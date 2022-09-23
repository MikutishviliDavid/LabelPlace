using AutoMapper;
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
            throw new System.NotImplementedException();
        }

        public async Task<CompanyDto> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CompanyDto> InsertAsync(CompanyDto company)
        {
            var companyE = _mapper.Map<Company>(company);

            await _unitOfWork.Company.InsertAsync(companyE);
            //await _unitOfWork.SaveAsync();// this logi needs to use in Dal layer

            return company;
        }

        public bool Update(CompanyDto company)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }  

        public CompanyDto Find(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
