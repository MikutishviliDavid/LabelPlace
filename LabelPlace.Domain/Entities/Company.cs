using System.Collections.Generic;

namespace LabelPlace.Domain.Entities
{
    public class Company : IntId
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public HashSet<Project> Projects { get; set; } = new HashSet<Project>();
    }
}
