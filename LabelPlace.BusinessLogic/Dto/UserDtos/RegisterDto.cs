using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto.UserDtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; } 

        public string Password { get; set; }

        public HashSet<ProjectDto> Projects { get; set; } = new HashSet<ProjectDto>();

        public HashSet<RoleDto> Roles { get; set; } = new HashSet<RoleDto>();
    }
}
