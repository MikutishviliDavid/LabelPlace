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
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(e => e.Email == email);

            var users = await _context.Users
                .Include(p => p.Roles)
                //.Include(p => p.Projects)
                .Where(p => p.Email == email)
                .ToListAsync();

            if (users.Count == 1)
            {
                return users[0];
            }
            
            return user; 
        }
    }
}
