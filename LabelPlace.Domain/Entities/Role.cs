﻿using LabelPlace.Domain.Enums;
using System.Collections.Generic;

namespace LabelPlace.Domain.Entities
{
    public class Role : IntId
    {
        public string Description { get; set; }

        public RoleType Type { get; set; }

        public HashSet<User> Users { get; set; } = new HashSet<User>();
    }
}