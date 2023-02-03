using LabelPlace.Dal.GenericRepository;
using LabelPlace.Dal.Repositories.Interfaces;
using LabelPlace.Domain.Entities;
using LabelPlace.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LabelPlace.Dal.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly LabelPlaceContext _context;

        public RoleRepository(LabelPlaceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> GetByTypeAsync(RoleType roleType)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Type == roleType);
        }
    }
}
