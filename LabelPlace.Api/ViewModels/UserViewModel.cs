using System.Collections.Generic;

namespace LabelPlace.Api.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public HashSet<ProjectViewModel> Projects { get; set; } = new HashSet<ProjectViewModel>();

        public HashSet<RoleViewModel> Roles { get; set; } = new HashSet<RoleViewModel>();
    }
}
