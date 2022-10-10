using LabelPlace.BusinessLogic.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        Task<CompanyDto> GetByIdAsync(int id);
        Task<CompanyDto> InsertAsync(CompanyDto company);
        Task Update(int id, CompanyDto company);
        Task DeleteAsync(int id);
    }
}
