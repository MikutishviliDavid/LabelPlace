using LabelPlace.BusinessLogic.Dto.UserDtos;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByEmailAsync(string email);
        Task<string> RegisterAsync(RegisterDto company, int roleId);
        Task<string> LoginAsync(LoginDto registerDto);
    }
}
