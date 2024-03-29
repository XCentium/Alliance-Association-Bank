﻿using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class Aq2ReformatEntityConfiguration : EntityTypeConfiguration<Aq2Reformat>
    {
        public Aq2ReformatEntityConfiguration()
        {
            ToTable("ReformatsAQ2");

            HasKey(e => e.ID);

            Property(e => e.ReformatName)
                .HasMaxLength(255);

            Property(e => e.Description)
                .HasMaxLength(255);

            Property(e => e.ECPReformatSpec)
                .HasMaxLength(255);

            Property(e => e.ECPPriorityOrder)
                .HasMaxLength(255);
        }
    }
}