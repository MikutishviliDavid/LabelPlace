using LabelPlace.Api.Models.CompanyModels;
using LabelPlace.Api.Models.Enums;
using LabelPlace.Api.Models.UserModels;
using System.Collections.Generic;

namespace LabelPlace.Api.Models
{
    public class CreateProjectRequest
    {
        public int UserId { get; set; }

        public int ComanyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SourceDataUrl { get; set; }

        public ProjectStatus Status { get; set; }

        public ProjectType Type { get; set; }

        public RegisterUserRequest User { get; set; }

        public CreateCompanyRequest Company { get; set; }
    }
}
