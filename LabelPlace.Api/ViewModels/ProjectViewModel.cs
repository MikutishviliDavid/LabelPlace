using LabelPlace.Api.ViewModels.Enums;
using System.Collections.Generic;

namespace LabelPlace.Api.ViewModels
{
    public class ProjectViewModel : BaseViewModel
    {
        public int UserId { get; set; }

        public int ComanyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SourceDataUrl { get; set; }

        public ProjectStatus? Status { get; set; }

        public ProjectType? Type { get; set; }

        public UserViewModel User { get; set; }

        public CompanyViewModel Company { get; set; }

        public HashSet<TextAnnotationViewModel> TextAnnotations { get; set; } = new HashSet<TextAnnotationViewModel>();
    }
}
