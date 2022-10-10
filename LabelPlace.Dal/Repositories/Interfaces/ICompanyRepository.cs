using LabelPlace.Dal.GenericRepository;
using LabelPlace.Domain.Entities;

namespace LabelPlace.Dal.Repositories.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        //IEnumerable<Company> GetByCountry(string country);
    }
}
