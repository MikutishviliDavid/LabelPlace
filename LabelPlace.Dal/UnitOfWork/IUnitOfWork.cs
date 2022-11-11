using LabelPlace.Dal.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace LabelPlace.Dal.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task SaveAsync();
    }
}
