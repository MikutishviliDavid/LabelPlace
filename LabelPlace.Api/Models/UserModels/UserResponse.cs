using LabelPlace.Domain.Entities;
using System.Collections.Generic;

namespace LabelPlace.Api.Models.UserModels
{
    public class UserResponse
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public HashSet<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
