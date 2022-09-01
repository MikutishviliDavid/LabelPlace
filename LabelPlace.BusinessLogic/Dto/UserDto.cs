using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public HashSet<ProjectDto> Projects { get; set; } = new HashSet<ProjectDto>();

        public HashSet<RoleDto> Roles { get; set; } = new HashSet<RoleDto>();
    }
}
