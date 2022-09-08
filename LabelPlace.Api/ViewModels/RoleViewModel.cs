using LabelPlace.Api.ViewModels.Enums;
using System.Collections.Generic;

namespace LabelPlace.Api.ViewModels
{
    public class RoleViewModel : BaseViewModel
    {
        public string Description { get; set; }

        public RoleType? Type { get; set; }

        public HashSet<UserViewModel> Users { get; set; } = new HashSet<UserViewModel>();
    }
}
