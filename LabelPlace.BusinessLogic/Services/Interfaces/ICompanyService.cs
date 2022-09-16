using LabelPlace.BusinessLogic.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        Task InsertAsync(CompanyDto company);
        void Update(CompanyDto company);
        void Delete(CompanyDto company);
    }
}
