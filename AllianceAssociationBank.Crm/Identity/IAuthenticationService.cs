namespace AllianceAssociationBank.Crm.Identity
{
    public interface IAuthenticationService
    {
        SignInResult PasswordSignIn(string userName, string password, bool isPersistent);
    }
}