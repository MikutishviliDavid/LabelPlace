using LabelPlace.BusinessLogic.Dtos.UserDtos;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDtoResponse> RegisterAsync(RegisterDto company, int roleId);

        Task<UserDtoResponse> LoginAsync(LoginDto registerDto);
    }
}
