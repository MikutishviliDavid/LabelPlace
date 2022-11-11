using AutoMapper;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Dal.UnitOfWork;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using LabelPlace.BusinessLogic.CustomExceptions;
using LabelPlace.BusinessLogic.Enums;
using System.Linq;
using LabelPlace.BusinessLogic.Dto.UserDtos;

namespace LabelPlace.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IConfiguration config, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _config = config;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email);

            if (user == null)
            {
                throw new BusinessLogicNotFoundException($"User with email: {email} not found.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<string> RegisterAsync(RegisterDto request, int roleId)
        {
            var userByEmail = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (userByEmail != null)
            {
                throw new BusinessLogicForbiddenException($"User with email: {userByEmail.Email} already exists.");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var userDto = new UserDto()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            var role = await _unitOfWork.Roles.GetByIdAsync(roleId); 
            /*if (role == null)*/
            // mapping RoleDto and  Role ?
            userDto.Roles.Add(role);

            var user = _mapper.Map<User>(userDto);

            await _unitOfWork.Users.InsertAsync(user);
            await _unitOfWork.SaveAsync();

            var token = CreateToken(user, role); // or UserDto

            //var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken);

            return token;
        }

        public async Task<string> LoginAsync(LoginDto request)               
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (user.Email != request.Email)
            {
                throw new BusinessLogicNotFoundException($"User with email: {user.Email} not found or entered an incorrect email address.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BusinessLogicBadRequest("Wrong password.");
            }

            var token = CreateToken(user, user.Roles.Last());

            return token;
        }

        private string CreateToken(User user, Role role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, role.Type.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
