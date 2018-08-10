using AllianceAssociationBank.Crm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class SoftwareEntityConfiguration : EntityTypeConfiguration<Software>
    {
        public SoftwareEntityConfiguration()
        {
            ToTable("Software");

            HasKey(e => e.ID);
        }
    }
}