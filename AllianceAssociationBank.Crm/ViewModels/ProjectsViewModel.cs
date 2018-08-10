using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ProjectsViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public int? SelectedProjectId { get; set; }
        public ProjectDetailViewModel SelectedProject { get; set; }
    }
}