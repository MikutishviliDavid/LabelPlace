using LabelPlace.Domain.Entities;
using System.Collections.Generic;

namespace LabelPlace.Api.Models.UserModels
{
    public class GetUserResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
