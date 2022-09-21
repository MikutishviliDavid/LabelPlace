using LabelPlace.BusinessLogic.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        Task<CompanyDto> GetAsync(int id);
        Task<CompanyDto> InsertAsync(CompanyDto company);
        bool Update(CompanyDto company);
        bool Delete(int id);
        CompanyDto Find(int id);
    }
}
