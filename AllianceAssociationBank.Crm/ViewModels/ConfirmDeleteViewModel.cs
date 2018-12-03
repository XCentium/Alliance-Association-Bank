using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ConfirmDeleteViewModel
    {
        public int? ParentId { get; set; }
        //public int ProjectId { get; set; }

        public int RecordIdToDelete { get; set; }

        public string AjaxDeleteRouteName { get; set; }

        public string AjaxUpdateTargetId { get; set; }

        public string ConfirmText { get; set; }
    }
}