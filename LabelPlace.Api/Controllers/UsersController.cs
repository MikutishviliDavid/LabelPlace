using AutoMapper;
using LabelPlace.Api.ViewModels.UserViewModels;
using LabelPlace.BusinessLogic.Dto.UserDtos;
using LabelPlace.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LabelPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel request, int roleId)
        {
            var userDto = _mapper.Map<RegisterDto>(request);

            var createdToken = await _userService.RegisterAsync(userDto, roleId);

            return Ok(createdToken);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel request)
        {
            var userDto = _mapper.Map<LoginDto>(request);

            var createdToken = await _userService.LoginAsync(userDto);

            return Ok(createdToken);
        }
    }
}
