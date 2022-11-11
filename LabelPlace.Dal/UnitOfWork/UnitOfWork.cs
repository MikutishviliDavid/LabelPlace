using LabelPlace.Dal.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace LabelPlace.Dal.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LabelPlaceContext _context;

        public ICompanyRepository Companies { get; }

        public IUserRepository Users { get; }

        public IRoleRepository Roles { get; }

        public UnitOfWork(LabelPlaceContext context, ICompanyRepository companies, IUserRepository users, IRoleRepository roles)
        {
            _context = context;
            Companies = companies;
            Users = users;
            Roles = roles;    
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
