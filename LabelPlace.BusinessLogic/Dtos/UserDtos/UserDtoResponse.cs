using LabelPlace.Domain.Entities;
using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dtos.UserDtos
{
    public class UserDtoResponse
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public HashSet<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
