using System.Collections.Generic;

namespace LabelPlace.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public ICollection<Project> Projects { get; set; } 
    }
}
