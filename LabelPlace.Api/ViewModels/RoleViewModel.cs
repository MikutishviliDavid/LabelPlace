using LabelPlace.Api.ViewModels.Enums;
using LabelPlace.Api.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace LabelPlace.Api.ViewModels
{
    public class RegisterViewModel
    {
        public string Description { get; set; }

        public RoleType Type { get; set; }

        public HashSet<UserViewModel> Users { get; set; } = new HashSet<UserViewModel>();
    }
}
