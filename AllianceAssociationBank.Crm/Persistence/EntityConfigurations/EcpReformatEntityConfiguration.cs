using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class EcpReformatEntityConfiguration : EntityTypeConfiguration<EcpReformat>
    {
        public EcpReformatEntityConfiguration()
        {
            ToTable("ReformatsECP");

            HasKey(e => e.ID);

            Property(e => e.ReformatName)
                .HasMaxLength(255);

            Property(e => e.Description)
                .HasMaxLength(255);
        }
    }
}