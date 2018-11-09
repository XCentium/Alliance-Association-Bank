using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AllianceAssociationBank.Crm.Persistence.EntityConfigurations;

namespace AllianceAssociationBank.Crm.Persistence
{
    public class CrmApplicationDbContext : DbContext
    {
        public virtual DbSet<CheckScanner> CheckScanners { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<Aq2Reformat> Aq2Reformats { get; set; }

        public CrmApplicationDbContext()
            : base("CrmApplicationDbConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CheckScannerEntityConfiguration());
            modelBuilder.Configurations.Add(new EmployeeEntityConfiguration());
            modelBuilder.Configurations.Add(new NoteEntityConfiguration());
            modelBuilder.Configurations.Add(new ProjectEntityConfiguration());
            modelBuilder.Configurations.Add(new ProjectUserEntityConfiguration());
            modelBuilder.Configurations.Add(new SoftwareEntityConfiguration());
            modelBuilder.Configurations.Add(new Aq2ReformatEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}