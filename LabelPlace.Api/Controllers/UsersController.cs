using AutoMapper;
using LabelPlace.Api.Configurations;
using LabelPlace.Api.Models.RoleModels;
using LabelPlace.Api.Models.UserModels;
using LabelPlace.BusinessLogic.Dtos.UserDtos;
using LabelPlace.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly LabelPlaceJwtConfiguration _jwtConfiguration;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController( IMapper mapper, IUserService userService, 
            IOptions<LabelPlaceJwtConfiguration> authConfiguration)
        {
            _jwtConfiguration = authConfiguration.Value;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var userDto = await _userService.GetByIdAsync(id);

            var user = _mapper.Map<GetUserResponse>(userDto);

            return Ok(user);
        }

        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterUserRequest request)
        {
            var registerDto = _mapper.Map<RegisterUserDtoRequest>(request);

            var userDtoResponse = await _userService.RegisterAsync(registerDto);

            var response = _mapper.Map<RegisterUserResponse>(userDtoResponse);

            return CreatedAtAction("GetById", new { id = response.Id }, response);
        }

        [HttpPost("sign-in")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginUserRequest request)
        {
            var loginDto = _mapper.Map<LoginUserDtoRequest>(request);

            var userDtoResponse = await _userService.LoginAsync(loginDto);

            var token = CreateToken(userDtoResponse);

            return Ok(token);
        }

        private string CreateToken(LoginUserDtoResponse user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user .LastName)
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Type.ToString()));
            }

            var token = new JwtSecurityToken(
                _jwtConfiguration.Issuer,
                _jwtConfiguration.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_jwtConfiguration.Lifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
