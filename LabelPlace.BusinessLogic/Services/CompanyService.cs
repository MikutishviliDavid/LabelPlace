using LabelPlace.BusinessLogic.Dto;
using LabelPlace.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services
{
    public class CompanyService : ICompanyService
    {
        public Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(CompanyDto company)
        {
            throw new System.NotImplementedException();
        }

        public void Update(CompanyDto company)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(CompanyDto company)
        {
            throw new System.NotImplementedException();
        }  
    }
}
