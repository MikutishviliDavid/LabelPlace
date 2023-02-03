using LabelPlace.Dal.Repositories.Implementations;
using LabelPlace.Dal.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace LabelPlace.Dal.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LabelPlaceContext _context;

        private ICompanyRepository _companyRepository;

        private IUserRepository _userRepository;

        private IRoleRepository _roleRepository;

        public ICompanyRepository Companies => _companyRepository ??= new CompanyRepository(_context);

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public IRoleRepository Roles => _roleRepository ??= new RoleRepository(_context);

        public UnitOfWork(LabelPlaceContext context)
        {
            _context = context; 
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
