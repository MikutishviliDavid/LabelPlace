﻿using LabelPlace.BusinessLogic.Dtos.Enums;
using LabelPlace.BusinessLogic.Dtos.UserDtos;
using System.Threading.Tasks;

namespace LabelPlace.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserDtoResponse> RegisterAsync(RegisterUserDtoRequest company);

        Task<LoginUserDtoResponse> LoginAsync(LoginUserDtoRequest registerDto);

        Task<LoginUserDtoResponse> GetByIdAsync(int id);

        Task AddRoleAsync(string email, RoleType roleRequest);

        Task DeleteRoleAsync(string email, RoleType roleRequest);
    }
}
