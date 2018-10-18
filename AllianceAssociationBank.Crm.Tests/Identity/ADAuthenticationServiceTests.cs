using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Identity;
using Microsoft.Owin.Security;
using Moq;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Identity
{
    public class ADAuthenticationServiceTests
    {
        private ADAuthenticationService authenticationService;

        private Mock<IActiveDirectoryContext> activeDirectoryContext;
        private Mock<IAuthenticationManager> authenticationManager;
        private UserPrincipal userPrincipal;
        private GroupPrincipal userAdminGroup;
        private IEnumerable<GroupPrincipal> userSecurityGroups;

        private string userName = "CrmUser1";
        private string password = "Pass01234";

        public ADAuthenticationServiceTests()
        {
            activeDirectoryContext = new Mock<IActiveDirectoryContext>();
            authenticationManager = new Mock<IAuthenticationManager>();
            userPrincipal = new UserPrincipal(new PrincipalContext(ContextType.Machine));
            userPrincipal.SamAccountName = userName;
            userAdminGroup = new GroupPrincipal(new PrincipalContext(ContextType.Machine));
            userSecurityGroups = new List<GroupPrincipal>() { userAdminGroup };

            authenticationService = new ADAuthenticationService(activeDirectoryContext.Object, authenticationManager.Object);
        }

        [Fact]
        public void PasswordSignIn_ValidUserWithValidCredentials_ShouldReturnSuccessSignInResult()
        {
            activeDirectoryContext.Setup(c => c.FindUserByName(userName)).Returns(userPrincipal);
            activeDirectoryContext.Setup(c => c.ValidateUserCredentials(userName, password)).Returns(true);
            activeDirectoryContext.Setup(c => c.GetUserSecurityGroups(userPrincipal)).Returns(userSecurityGroups);
            userAdminGroup.Name = UserAuthenticationSettings.AdminADGroup;

            var result = authenticationService.PasswordSignIn(userName, password, false);

            Assert.Equal(SignInResult.Success, result);
        }

        [Fact]
        public void PasswordSignIn_ValidUserWithInvalidCredentials_ShouldReturnInvalidCredentialsSignInResult()
        {
            activeDirectoryContext.Setup(c => c.FindUserByName(userName)).Returns(userPrincipal);
            activeDirectoryContext.Setup(c => c.ValidateUserCredentials(userName, password)).Returns(false);

            var result = authenticationService.PasswordSignIn(userName, password, false);

            Assert.Equal(SignInResult.InvalidCredentials, result);
        }

        [Fact]
        public void PasswordSignIn_ValidUserButNotAuthorized_ShouldReturnNotAuthorizedSignInResult()
        {
            activeDirectoryContext.Setup(c => c.FindUserByName(userName)).Returns(userPrincipal);
            activeDirectoryContext.Setup(c => c.ValidateUserCredentials(userName, password)).Returns(true);
            activeDirectoryContext.Setup(c => c.GetUserSecurityGroups(userPrincipal)).Returns(new List<GroupPrincipal>());

            var result = authenticationService.PasswordSignIn(userName, password, false);

            Assert.Equal(SignInResult.NotAuthorized, result);
        }

        [Fact]
        public void PasswordSignIn_ValidUserAndExceptionThrown_ShouldReturnErrorOccurredSignInResult()
        {
            activeDirectoryContext.Setup(c => c.FindUserByName(userName)).Returns(userPrincipal);
            activeDirectoryContext.Setup(c => c.ValidateUserCredentials(userName, password)).Throws(new Exception());

            var result = authenticationService.PasswordSignIn(userName, password, false);

            Assert.Equal(SignInResult.ErrorOccurred, result);
        }

        [Fact]
        public void SignOut_ValidState_ShouldNotThrowException()
        {
            authenticationService.SignOut();
        }

        [Fact]
        public void CreateUserIdentity_ValidAdminUser_ShouldReturnIdentiyWithAdminRole()
        {
            activeDirectoryContext.Setup(c => c.GetUserSecurityGroups(userPrincipal)).Returns(userSecurityGroups);
            userAdminGroup.Name = UserAuthenticationSettings.AdminADGroup;

            var identity = authenticationService.CreateUserIdentity(userPrincipal);

            Assert.NotNull(identity);
            Assert.Single(identity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList());
            Assert.Equal(UserRole.Admin, identity.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value);
        }

        [Fact]
        public void CreateUserIdentity_ValidReadWriteUser_ShouldReturnIdentiyWithReadWriteRole()
        {
            activeDirectoryContext.Setup(c => c.GetUserSecurityGroups(userPrincipal)).Returns(userSecurityGroups);
            userAdminGroup.Name = UserAuthenticationSettings.ReadWriteADGroup;

            var identity = authenticationService.CreateUserIdentity(userPrincipal);

            Assert.NotNull(identity);
            Assert.Single(identity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList());
            Assert.Equal(UserRole.ReadWriteUser, identity.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value);
        }


        [Fact]
        public void CreateUserIdentity_ValidReadOnlyUser_ShouldReturnIdentiyWithReadOnlyRole()
        {
            activeDirectoryContext.Setup(c => c.GetUserSecurityGroups(userPrincipal)).Returns(userSecurityGroups);
            userAdminGroup.Name = UserAuthenticationSettings.ReadOnlyADGroup;

            var identity = authenticationService.CreateUserIdentity(userPrincipal);

            Assert.NotNull(identity);
            Assert.Single(identity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList());
            Assert.Equal(UserRole.ReadOnlyUser, identity.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value);
        }

        [Fact]
        public void CreateUserIdentity_InvalidUser_ShouldReturnNull()
        {
            activeDirectoryContext.Setup(c => c.GetUserSecurityGroups(userPrincipal)).Returns(userSecurityGroups);
            userAdminGroup.Name = "Some Security Group 999";

            var identity = authenticationService.CreateUserIdentity(userPrincipal);

            Assert.Null(identity);
        }
    }
}
