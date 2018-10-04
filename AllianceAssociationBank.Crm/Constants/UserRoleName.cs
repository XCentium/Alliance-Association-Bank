namespace AllianceAssociationBank.Crm.Constants
{
    public static class UserRole
    {
        public const string Admin = "Admin";
        public const string ReadWriteUser = "ReadWriteUser";
        public const string ReadOnlyUser = "ReadOnlyUser";

        public const string EditAccessRoles = Admin + ", " + ReadWriteUser;
    }
}