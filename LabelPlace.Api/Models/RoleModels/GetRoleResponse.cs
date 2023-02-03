using LabelPlace.Api.Models.Enums;

namespace LabelPlace.Api.Models.RoleModels
{
    public class GetRoleResponse
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public RoleType Type { get; set; }
    }
}
