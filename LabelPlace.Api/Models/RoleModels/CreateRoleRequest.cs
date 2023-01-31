using LabelPlace.Api.Models.Enums;
using LabelPlace.Api.Models.UserModels;
using System.Collections.Generic;

namespace LabelPlace.Api.Models.RoleModels
{
    public class CreateRoleRequest
    {
        public string Description { get; set; }

        public RoleType Type { get; set; }
    }
}
