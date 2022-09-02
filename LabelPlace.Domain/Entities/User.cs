﻿using System.Collections.Generic;

namespace LabelPlace.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public HashSet<Project> Projects { get; set; } = new HashSet<Project>();

        public HashSet<Role> Roles { get; set; } = new HashSet<Role>(); 
    }
}