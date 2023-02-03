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

        public async Task<LoginUserDtoResponse> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                throw new BusinessLogicNotFoundException($"User with Id: {id} not found.");
            }

            return _mapper.Map<LoginUserDtoResponse>(user);
        }

        public async Task<RegisterUserDtoResponse> RegisterAsync(RegisterUserDtoRequest request)
        {
            var userByEmail = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (userByEmail != null)
            {
                throw new BusinessLogicAlreadyExistsException($"User with email: {userByEmail.Email} already exists.");
            }

            CreatePasswordHash(request.Password, out string passwordHash, out string passwordSalt);

            var userDto = new NewUserDto()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            var role = await _unitOfWork.Roles.GetByTypeAsync(Domain.Enums.RoleType.Undefined);

            userDto.Roles.Add(role);

            var user = _mapper.Map<User>(userDto);

            await _unitOfWork.Users.InsertAsync(user);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<RegisterUserDtoResponse>(user);
        }

        public async Task<LoginUserDtoResponse> LoginAsync(LoginUserDtoRequest request)               
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new BusinessLogicBadRequest("Invalid login or password.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BusinessLogicBadRequest("Invalid login or password.");
            }

            return _mapper.Map<LoginUserDtoResponse>(user);
        }

        public async Task AddRoleAsync(string email, RoleType roleRequest)
        {
            var userByEmail = await _unitOfWork.Users.GetByEmailAsync(email);

            if (userByEmail == null)
            {
                throw new BusinessLogicNotFoundException($"User with email: {email} not found.");
            }

            var roleType = _mapper.Map<Domain.Enums.RoleType>(roleRequest);

            var role = await _unitOfWork.Roles.GetByTypeAsync(roleType);

            if (role == null)
            {
                throw new BusinessLogicNotFoundException($"Role with type: {roleType} not found.");
            }

            userByEmail.Roles.Add(role);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteRoleAsync(string email, RoleType roleRequest)
        {
            var userByEmail = await _unitOfWork.Users.GetByEmailAsync(email);

            if (userByEmail == null)
            {
                throw new BusinessLogicNotFoundException($"User with email: {email} not found.");
            }

            var roleType = _mapper.Map<Domain.Enums.RoleType>(roleRequest);

            var role = await _unitOfWork.Roles.GetByTypeAsync(roleType);

            if (role == null)
            {
                throw new BusinessLogicNotFoundException($"Role with type: {roleType} not found.");
            }

            userByEmail.Roles.Remove(role);

            await _unitOfWork.SaveAsync();
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
