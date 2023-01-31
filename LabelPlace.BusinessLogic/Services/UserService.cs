using AutoMapper;
using LabelPlace.BusinessLogic.Services.Interfaces;
using LabelPlace.Dal.UnitOfWork;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using LabelPlace.BusinessLogic.CustomExceptions;
using LabelPlace.BusinessLogic.Dtos.Enums;
using System.Linq;
using LabelPlace.BusinessLogic.Dtos.UserDtos;

namespace LabelPlace.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDtoResponse> RegisterAsync(RegisterDto request, int roleId)
        {
            var userByEmail = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (userByEmail != null)
            {
                throw new BusinessLogicAlreadyExistsException($"User with email: {userByEmail.Email} already exists.");
            }

            CreatePasswordHash(request.Password, out string passwordHash, out string passwordSalt);

            var userDto = new UserDto()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            var role = await _unitOfWork.Roles.GetByIdAsync(roleId);

            if (role == null)
            {
                throw new BusinessLogicNotFoundException($"Role with Id: {roleId} not found.");
            }

            userDto.Roles.Add(role);

            var user = _mapper.Map<User>(userDto);

            await _unitOfWork.Users.InsertAsync(user);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<UserDtoResponse>(user);
        }

        public async Task<UserDtoResponse> LoginAsync(LoginDto request)               
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (user == null || user.Email != request.Email)
            {
                throw new BusinessLogicNotFoundException($"User with email: {request.Email} not found or entered an incorrect email address.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BusinessLogicBadRequest("Wrong password.");
            }

            return _mapper.Map<UserDtoResponse>(user);
        }

        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using var hmac = new HMACSHA512();
            byte[] Salt = hmac.Key;
            byte[] Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            passwordHash = Convert.ToBase64String(Hash);
            passwordSalt = Convert.ToBase64String(Salt);
        }

        private bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            byte[] Hash = Convert.FromBase64String(storedHash);
            byte[] Salt = Convert.FromBase64String(storedSalt);

            using var hmac = new HMACSHA512(Salt);
            byte[] enteredHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            return enteredHash.SequenceEqual(Hash);
        }
    }
}
