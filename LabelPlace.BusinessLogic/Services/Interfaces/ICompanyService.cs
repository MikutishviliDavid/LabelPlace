using LabelPlace.BusinessLogic.Dto;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        Task<CompanyDto> GetAsync(int id);
        Task<CompanyDto> InsertAsync(CompanyDto company);
        Task Update(CompanyDto company);
        Task DeleteAsync(int id);
    }
}
