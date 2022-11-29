using LabelPlace.BusinessLogic.Enums;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto.UserDtos
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        /*public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }*/

        public HashSet<ProjectDto> Projects { get; set; } = new HashSet<ProjectDto>();

        public HashSet<Role> Roles { get; set; } = new HashSet<Role>(); // RoleDto 
    }
}
