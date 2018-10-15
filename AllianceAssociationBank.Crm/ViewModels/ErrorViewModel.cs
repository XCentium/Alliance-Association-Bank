using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ErrorViewModel
    {
        public string ErrorTitle { get; set; }
        public string ErrorMessage { get; set; }
        public string PreviousPageUrl { get; set; }

        public ErrorViewModel()
        {

        }

        public ErrorViewModel(string errorTitle, string errorMessage, string previousPageUrl = null)
        {
            ErrorTitle = errorTitle;
            ErrorMessage = errorMessage;
            PreviousPageUrl = string.IsNullOrEmpty(previousPageUrl) ? "/" : previousPageUrl;
        }
    }
}