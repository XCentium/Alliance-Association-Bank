using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class ProjectUserEntityConfiguration : EntityTypeConfiguration<ProjectUser>
    {
        public ProjectUserEntityConfiguration()
        {
            ToTable("Users");

            HasKey(e => e.ID);

            Property(e => e.Birthday)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.DateAdded)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.DateDeleted)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            //Property(e => e.Attachments)
            //    .IsUnicode(false);

            HasRequired(u => u.Project)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProjectID);


        }
    }
}