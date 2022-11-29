using LabelPlace.Dal.GenericRepository;
using LabelPlace.Dal.Repositories.Interfaces;
using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LabelPlace.Dal.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly LabelPlaceContext _context;

        public UserRepository(LabelPlaceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.Users
                .Include(p => p.Roles)
                .FirstOrDefaultAsync(p => p.Email == email);
            
            return user; 
        }
    }
}
