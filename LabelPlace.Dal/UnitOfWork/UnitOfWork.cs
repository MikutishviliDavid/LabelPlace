using LabelPlace.Dal.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace LabelPlace.Dal.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LabelPlaceContext _context;

        public ICompanyRepository Company { get; }

        public UnitOfWork(LabelPlaceContext context, ICompanyRepository companyRepository)
        {
            _context = context;
            Company = companyRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
