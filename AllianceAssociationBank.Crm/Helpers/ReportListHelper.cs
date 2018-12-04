using AllianceAssociationBank.Crm.Constants.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Helpers
{
    public class ReportListHelper
    {
        public static IEnumerable<SelectListItem> GetStandardReports()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Value = ReportName.Boarding, Text = "Boarding" },
                new SelectListItem() { Value = ReportName.CompletedAndHold, Text = "Completed and Hold" },
                new SelectListItem() { Value = ReportName.SoftwareTransition, Text = "Software Transition" },
                new SelectListItem() { Value = ReportName.CmcById, Text = "CMC By ID" },
                new SelectListItem() { Value = ReportName.CmcByName, Text = "CMC By Name" },
                new SelectListItem() { Value = ReportName.CDEmails, Text = "CD Emails" },
                new SelectListItem() { Value = ReportName.Coupon, Text = "Coupon" },

                new SelectListItem() { Value = ReportName.AchAllCompanies, Text = "ACH All Companies" },
                new SelectListItem() { Value = ReportName.CipReview, Text = "CIP Review" },
                new SelectListItem() { Value = ReportName.CmcByIdUsefulInfo, Text = "CMC By ID Useful Info" },
                new SelectListItem() { Value = ReportName.IncorrectEmployeeData, Text = "Incorrect Employee Data" },
            };
        }

        public static IEnumerable<SelectListItem> GetExports()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Value = ExportName.CmcList, Text = "CMC List" },
                new SelectListItem() { Value = ExportName.CmcUsefulInfoList, Text = "CMC Useful Info List" },
                new SelectListItem() { Value = ExportName.AllInfo, Text = "All Info" }
            };
        }
    }
}