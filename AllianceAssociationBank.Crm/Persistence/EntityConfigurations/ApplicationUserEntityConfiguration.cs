using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class ApplicationUserEntityConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserEntityConfiguration()
        {
            Property(u => u.FirstName)
                .HasMaxLength(100);

            Property(u => u.LastName)
                .HasMaxLength(100);
        }
    }
}