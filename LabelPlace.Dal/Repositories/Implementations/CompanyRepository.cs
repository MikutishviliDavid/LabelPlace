﻿using LabelPlace.Dal.GenericRepository;
using LabelPlace.Dal.Repositories.Interfaces;
using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        //public IEnumerable<Company> GetByCountry(string country)
        //{
        //    return _context.Companies.Where(c => c.Country == country);
        //} add to ICompanyRepository

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
