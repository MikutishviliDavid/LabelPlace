using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dtos.UserDtos
{
    public class RegisterUserDtoRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; } 

        public string Password { get; set; }
    }
}
