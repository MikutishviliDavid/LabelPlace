using System.Collections.Generic;

namespace LabelPlace.Api.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public string Username { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public HashSet<ProjectViewModel> Projects { get; set; } = new HashSet<ProjectViewModel>();

        public HashSet<RegisterViewModel> Roles { get; set; } = new HashSet<RegisterViewModel>();
    }
}
