using LabelPlace.Api.ViewModels.CompanyViewModels;
using LabelPlace.Api.ViewModels.Enums;
using LabelPlace.Api.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace LabelPlace.Api.ViewModels
{
    public class ProjectViewModel
    {
        public int UserId { get; set; }

        public int ComanyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SourceDataUrl { get; set; }

        public ProjectStatus Status { get; set; }

        public ProjectType Type { get; set; }

        public UserViewModel User { get; set; }

        public CreateCompanyRequest Company { get; set; }

        public HashSet<TextAnnotationViewModel> TextAnnotations { get; set; } = new HashSet<TextAnnotationViewModel>();
    }
}
