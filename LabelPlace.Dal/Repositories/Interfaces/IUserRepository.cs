using LabelPlace.Dal.GenericRepository;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabelPlace.Dal.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
