namespace AllianceAssociationBank.Crm.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CrmApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AllianceAssociationBank.Crm.Persistence.CrmApplicationDbContext";
        }
    }
}
