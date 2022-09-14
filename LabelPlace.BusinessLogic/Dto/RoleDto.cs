using LabelPlace.BusinessLogic.Enums;
using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto
{
    public class RoleDto : BaseIntIdDto
    {
        public string Description { get; set; }

        public RoleType Type { get; set; }

        public HashSet<UserDto> Users { get; set; } = new HashSet<UserDto>();
    }
}
