using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.ProjectUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.Enums
{
    public static class EnumConversionExtensions
    {
        public static SortOrder ToSortOrderEnum(this string sortOrderString)
        {
            switch (sortOrderString)
            {
                case SortOrderString.Ascending:
                    return SortOrder.Ascending;
                case SortOrderString.Descending:
                    return SortOrder.Descending;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static UserFilter ToUserFilterEnum(this string userFilterString)
        {
            switch (userFilterString)
            {
                case UserFilterString.All:
                    return UserFilter.All;
                case UserFilterString.Admin:
                    return UserFilter.Admin;
                case UserFilterString.Active:
                    return UserFilter.Active;
                case UserFilterString.Inactive:
                    return UserFilter.Inactive;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}