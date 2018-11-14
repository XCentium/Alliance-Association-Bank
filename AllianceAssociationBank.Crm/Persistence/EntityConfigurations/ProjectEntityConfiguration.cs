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

            Property(e => e.ProjectName)
                .HasMaxLength(150);

            Property(e => e.Institution)
                .HasMaxLength(255);

            Property(e => e.Status)
                .HasMaxLength(50);

            Property(e => e.StartDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.EndDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.TargetLockboxLiveDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.Address)
                .HasMaxLength(255);

            Property(e => e.City)
                .HasMaxLength(255);

            Property(e => e.State)
                .HasMaxLength(255);

            Property(e => e.ZipCode)
                .HasMaxLength(255);

            Property(e => e.MailingAddress)
                .HasMaxLength(255);

            Property(e => e.MailingCity)
                .HasMaxLength(255);

            Property(e => e.MailingState)
                .HasMaxLength(255);

            Property(e => e.MailingZipCode)
                .HasMaxLength(255);

            Property(e => e.Website)
                .HasMaxLength(255);

            Property(e => e.TIN)
                .HasMaxLength(255);

            Property(e => e.DBA)
                .HasMaxLength(255);

            Property(e => e.Fax)
                .HasMaxLength(255);

            Property(e => e.Phone)
                .HasMaxLength(255);

            Property(e => e.TimeZone)
                .HasMaxLength(255);

            Property(e => e.Software)
                .HasMaxLength(255);

            Property(e => e.EstimatedDeposits)
                .HasPrecision(16, 4);

            Property(e => e.ActualDeposits)
                .HasPrecision(16, 4);

            Property(e => e.LockboxCMCID)
                .HasMaxLength(10);

            Property(e => e.POBoxSize)
                .HasMaxLength(255);

            Property(e => e.POBoxLine1)
                .HasMaxLength(255);

            Property(e => e.POBoxZipCode)
                .HasMaxLength(255);

            Property(e => e.CouponVender)
                .HasMaxLength(255);

            Property(e => e.CouponVenderNumber)
                .HasMaxLength(255);

            Property(e => e.DICompanyID)
                .HasMaxLength(255);

            Property(e => e.SftpFolderName)
                .HasMaxLength(255);

            Property(e => e.SftpGeneralUserPassword)
                .HasMaxLength(255);

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

            Property(e => e.CorporateAccounts)
                .HasMaxLength(255);

            Property(e => e.XmlAutoReconSentDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.SftpUsage)
                .HasMaxLength(255);

            Property(e => e.XmlUsage)
                .HasMaxLength(255);

            Property(e => e.LockboxLiveDate)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.LockboxStatus)
                .HasMaxLength(50);

            Property(e => e.LockboxSystem)
                .HasMaxLength(50);

            Property(e => e.SftpPath)
                .HasMaxLength(100);

            Property(e => e.MigratingToSoftware)
                .HasMaxLength(255);

            Property(e => e.OtherName)
                .HasMaxLength(255);

            Property(e => e.RelationshipRate)
                .HasMaxLength(50);

            HasOptional(e => e.Owner)
                .WithMany()
                .HasForeignKey(e => e.OwnerID);

            HasOptional(e => e.AFP)
                .WithMany()
                .HasForeignKey(e => e.AFPID);

            HasOptional(e => e.BoardingManager)
                .WithMany()
                .HasForeignKey(e => e.BoardingManagerID);

            HasOptional(e => e.ReformatAQ2)
                .WithMany()
                .HasForeignKey(e => e.ReformatAQ2ID);
        }
    }
}