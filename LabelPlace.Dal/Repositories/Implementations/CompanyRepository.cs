using LabelPlace.Dal.GenericRepository;
using LabelPlace.Dal.Repositories.Interfaces;
using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.Dal.Repositories.Implementations
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(LabelPlaceContext context) : base(context)
        {
        }

        //public IEnumerable<Company> GetByCountry(string country)
        //{
        //    return _context.Companies.Where(c => c.Country == country);
        //}

        /*public void Delete(Company entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(Company entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Company entity)
        {
            throw new System.NotImplementedException();
        }*/
    }
}
