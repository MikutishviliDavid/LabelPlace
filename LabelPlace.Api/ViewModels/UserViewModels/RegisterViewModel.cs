namespace LabelPlace.Api.ViewModels.UserViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; } // while it is also Username

        public string Password { get; set; }
    }
}
