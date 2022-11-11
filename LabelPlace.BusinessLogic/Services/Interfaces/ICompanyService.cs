using LabelPlace.BusinessLogic.Dto.CompanyDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CreateCompanyDtoResponse>> GetAllAsync();
        Task<IEnumerable<CreateCompanyDtoResponse>> GetAllByCountryAsync(string country);
        Task<CreateCompanyDtoResponse> GetByIdAsync(int id);
        Task<CreateCompanyDtoResponse> InsertAsync(CreateCompanyDtoRequest company);
        Task UpdateAsync(int id, UpdateCompanyDto company);
        Task DeleteAsync(int id);
    }
}
