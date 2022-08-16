using System.Collections.Generic;

namespace LabelPlace.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Role> Roles { get; set; }  
    }
}