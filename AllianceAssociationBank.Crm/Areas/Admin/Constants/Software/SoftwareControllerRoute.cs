using AllianceAssociationBank.Crm.Constants;

namespace AllianceAssociationBank.Crm.Areas.Admin.Constants.Software
{
    public static class SoftwareControllerRoute
    {
        public const string GetSoftwareList = ControllerName.Software + "GetSoftwareList";
        public const string CreateSoftware = ControllerName.Software + "CreateSoftware";
        public const string CreateSoftwareHttpPost = ControllerName.Software + "CreateSoftwareHttpPost";
        public const string ConfirmDeleteSoftware = ControllerName.Software + "ConfirmDeleteSoftware";
        public const string DeleteSoftware = ControllerName.Software + "DeleteSoftware";
    }
}