using LabelPlace.BusinessLogic.Dtos.Enums;
using LabelPlace.Domain.Entities;
using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dtos.UserDtos
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public HashSet<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
