using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class NoteEntityConfiguration : EntityTypeConfiguration<Note>
    {
        public NoteEntityConfiguration()
        {
            ToTable("Notes");

            HasKey(e => e.ID);

            Property(e => e.DateAdded)
                .HasColumnType("datetime2")
                .HasPrecision(0);
        }
    }
}