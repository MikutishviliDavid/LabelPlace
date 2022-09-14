using System;
using System.Threading.Tasks;

namespace LabelPlace.Dal.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
