using LabelPlace.Dal.GenericRepository;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.Dal.Repositories.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllByCountryAsync(string country);

        Task<Company> GetByNameAsync(string companyName);
    }
}
