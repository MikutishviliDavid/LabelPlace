using LabelPlace.Api.Models.Enums;

namespace LabelPlace.Api.Models.UserModels
{
    public class DeleteUserRoleRequest
    {
        public string UserEmail { get; set; }

        public RoleType Type { get; set; }
    }
}
