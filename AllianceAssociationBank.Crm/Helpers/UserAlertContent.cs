using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Helpers
{
    public static class UserAlertContent
    {
        public static string GetConfirmDeleteMessage(int countOfAssociatedActiveProjects)
        {
            const string AreYouSureYouWantToDelete = "Are you sure you want to delete this record?";

            string associatedRecordsText;
            if (countOfAssociatedActiveProjects < 1)
            {
                associatedRecordsText = "No active projects associated with this record.";
            }
            else if (countOfAssociatedActiveProjects == 1)
            {
                associatedRecordsText = "1 active project associated with this record.";
            }
            else
            {
                associatedRecordsText = $"{countOfAssociatedActiveProjects} active projects associated with this record.";
            }

            return $"{associatedRecordsText} {AreYouSureYouWantToDelete}";
        }
    }
}