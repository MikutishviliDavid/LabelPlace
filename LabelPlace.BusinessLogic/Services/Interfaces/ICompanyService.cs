using LabelPlace.BusinessLogic.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        CompanyDto Get(int id);
        Task InsertAsync(CompanyDto company);
        bool Update(CompanyDto company);
        bool Delete(CompanyDto company);
        CompanyDto Find(int id);
    }
}
