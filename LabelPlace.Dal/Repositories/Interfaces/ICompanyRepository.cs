using LabelPlace.Dal.GenericRepository;
using LabelPlace.Domain.Entities;

namespace LabelPlace.Dal.Repositories.Interfaces
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        /*Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetAsync(int id);
        void CreateCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int id);*/
    }
}
