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

            Property(e => e.Name)
                .HasMaxLength(255);

            Property(e => e.Email)
                .HasMaxLength(255);

            Property(e => e.Title)
                .HasMaxLength(255);

            Property(e => e.DI)
                .HasMaxLength(255);

            Property(e => e.Sftp)
                .HasMaxLength(255);

            Property(e => e.LockboxWeb)
                .HasMaxLength(255);

            Property(e => e.EDeposit)
                .HasMaxLength(255);

            Property(e => e.Phone)
                .HasMaxLength(255);

            Property(e => e.Mobile)
                .HasMaxLength(255);

            Property(e => e.RemoteScannerAccountNotes)
                .HasMaxLength(255);

            Property(e => e.Birthday)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.DateAdded)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.DateDeleted)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            HasRequired(u => u.Project)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProjectID);


        }
    }
}