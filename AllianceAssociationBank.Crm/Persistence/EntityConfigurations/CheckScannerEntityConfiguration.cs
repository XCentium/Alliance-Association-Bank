using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class CheckScannerEntityConfiguration : EntityTypeConfiguration<CheckScanner>
    {
        public CheckScannerEntityConfiguration()
        {
            ToTable("CheckScanners");

            HasKey(e => e.ID);

            Property(e => e.Model)
                .HasMaxLength(255);

            Property(e => e.SerialNumber)
                .HasMaxLength(255);

            Property(e => e.DateMailed)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.DateInstalled)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.DateTrained)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            Property(e => e.ComputerInstalledOn)
                .HasMaxLength(255);

            Property(e => e.System)
                .HasMaxLength(255);
        }
    }
}