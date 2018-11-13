namespace AllianceAssociationBank.Crm.Identity
{
    /// <summary>
    /// A claims-based user authentication service.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Sign in a user using username and password and create claims based user identity on success.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isPersistent">Should the authentication session be persisted across multiple requests.</param>
        /// <returns>Returns SignInResult enum with result.</returns>
        SignInResult PasswordSignIn(string userName, string password, bool isPersistent);

        /// <summary>
        /// Sign out current logged in user.
        /// </summary>
        void SignOut();
    }
}