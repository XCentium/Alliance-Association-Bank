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
        //}
    }
}
