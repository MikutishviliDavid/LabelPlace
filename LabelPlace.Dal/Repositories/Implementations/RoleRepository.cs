using LabelPlace.Dal.GenericRepository;
using LabelPlace.Dal.Repositories.Interfaces;
using LabelPlace.Domain.Entities;

namespace LabelPlace.Dal.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly LabelPlaceContext _context;

        public RoleRepository(LabelPlaceContext context) : base(context)
        {
            _context = context;
        }
    }
}
