using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class ProjectEntityConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectEntityConfiguration()
        {
            ToTable("Projects");

            HasKey(e => e.ID);

            Property(e => e.StartDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.EndDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.TargetLockboxLiveDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.Attachments)
                .IsUnicode(false);

            Property(e => e.EstimatedDeposits)
                .HasPrecision(16, 4);

            Property(e => e.ActualDeposits)
                .HasPrecision(16, 4);

            Property(e => e.ACHEstimatedDeposits)
                .HasPrecision(16, 4);

            Property(e => e.ACHEstimatedDepositsDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.ACHLimit)
                .HasPrecision(16, 4);

            Property(e => e.ACHSystemLimit)
                .HasPrecision(16, 4);

            Property(e => e.OriginalReviewDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.LastReviewDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.XmlAutoReconSentDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.LockboxLiveDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            //HasOptional(e => e.Owner).WithMany()
            //    .HasForeignKey(e => e.OwnerID);

            //HasOptional(e => e.AFP).WithMany()
            //    .HasForeignKey(e => e.AFPID);
        }
    }
}