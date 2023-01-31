using LabelPlace.BusinessLogic.Dtos.CompanyDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<GetCompanyDtoResponse>> GetAllAsync();

        Task<IEnumerable<GetCompanyDtoResponse>> GetAllByCountryAsync(string country);

        Task<GetCompanyDtoResponse> GetByIdAsync(int id);

        Task<CreateCompanyDtoResponse> InsertAsync(CreateCompanyDtoRequest company);

        Task UpdateAsync(int id, UpdateCompanyDto company);

        Task DeleteAsync(int id);
    }
}
