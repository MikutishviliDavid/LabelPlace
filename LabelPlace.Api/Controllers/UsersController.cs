using AutoMapper;
using LabelPlace.Api.Configurations;
using LabelPlace.Api.Models.RoleModels;
using LabelPlace.Api.Models.UserModels;
using LabelPlace.BusinessLogic.Dtos.UserDtos;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LabelPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IConfiguration config, IMapper mapper, IUserService userService)
        {
            _config = config;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterUserRequest request, int roleId = 1)
        {
            var registerDto = _mapper.Map<RegisterDto>(request);

            var userDtoResponse = await _userService.RegisterAsync(registerDto, roleId);

            var userResponse = _mapper.Map<UserResponse>(userDtoResponse);

            var token = CreateToken(userResponse, userResponse.Roles.Last());

            return Ok(token);
        }

        [HttpPost("sign-in")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginUserRequest request)
        {
            var loginDto = _mapper.Map<LoginDto>(request);

            var userDtoResponse = await _userService.LoginAsync(loginDto);

            var userResponse = _mapper.Map<UserResponse>(userDtoResponse);

            var token = CreateToken(userResponse, userResponse.Roles.Last());

            return Ok(token);
        }

        private string CreateToken(UserResponse user, Role role)
        {
            var jwt = _config.GetSection("Jwt").Get<LabelPlaceJwtConfiguration>();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user .LastName),
                new Claim(ClaimTypes.Role, role.Type.ToString())
            };

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwt.Lifetime)),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
