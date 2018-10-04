namespace AllianceAssociationBank.Crm.Persistence.Migrations
{
    using AllianceAssociationBank.Crm.Constants;
    using AllianceAssociationBank.Crm.Core.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrmApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AllianceAssociationBank.Crm.Persistence.CrmApplicationDbContext";
        }

        //protected override void Seed(CrmApplicationDbContext context)
        //{
        //    var identityDbContext = new CrmApplicationDbContext();
        //}

        //private void CreateUserRoles(DbContext dbContext)
        //{
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

        //    if (!roleManager.RoleExists(UserRole.Admin))
        //    {
        //        roleManager.Create(new IdentityRole(UserRole.Admin));
        //    }

        //    if (!roleManager.RoleExists(UserRole.ReadWriteUser))
        //    {
        //        roleManager.Create(new IdentityRole(UserRole.ReadWriteUser));
        //    }

        //    if (!roleManager.RoleExists(UserRole.ReadOnlyUser))
        //    {
        //        roleManager.Create(new IdentityRole(UserRole.ReadOnlyUser));
        //    }
        //}

        //private void CreateAdminUser(DbContext dbContext)
        //{
        //    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));

        //    if (userManager.FindByEmail("admin@xcentium.com") == null)
        //    {
        //        // TODO: store this info as app config
        //        var adminUser = new ApplicationUser()
        //        {
        //            UserName = "admin@xcentium.com",
        //            Email = "admin@xcentium.com",
        //        };
        //        userManager.Create(adminUser, "Password1!");
        //        userManager.AddToRole(adminUser.Id, UserRole.Admin);
        //    }
        //}
    }
}
