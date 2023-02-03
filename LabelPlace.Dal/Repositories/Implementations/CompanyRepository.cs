using LabelPlace.Dal.GenericRepository;
using LabelPlace.Dal.Repositories.Interfaces;
using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelPlace.Dal.Repositories.Implementations
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly LabelPlaceContext _context;

        public CompanyRepository(LabelPlaceContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Company>> GetAllByCountryAsync(string country)
        {
           return await _context.Companies.AsNoTracking().Where(c => c.Country == country).ToListAsync();
        }

        public async Task<Company> GetByNameAsync(string companyName)
        {
            return await _context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Name == companyName);
        }
    }
}
