using LabelPlace.Domain.Enums;
using System.Collections.Generic;

namespace LabelPlace.Domain.Entities
{
    public class Role : BaseEntity
    {
        public RoleType Type { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}