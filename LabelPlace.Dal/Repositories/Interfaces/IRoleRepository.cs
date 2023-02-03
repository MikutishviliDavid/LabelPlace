using LabelPlace.Dal.GenericRepository;
using LabelPlace.Domain.Entities;
using LabelPlace.Domain.Enums;
using System.Threading.Tasks;

namespace LabelPlace.Dal.Repositories.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetByTypeAsync(RoleType roleType);
    }
}
