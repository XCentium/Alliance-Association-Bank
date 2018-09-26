using AllianceAssociationBank.Crm.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AllianceAssociationBank.Crm.Persistence.EntityConfigurations;

namespace AllianceAssociationBank.Crm.Persistence
{
    public class CrmApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<CheckScanner> CheckScanners { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<Aq2Reformat> Aq2Reformats { get; set; }
        public virtual DbSet<EcpReformat> EcpReformats { get; set; }

        public CrmApplicationDbContext()
            : base("CrmApplicationDbConnection", throwIfV1Schema: false)
        {
        }

        public static CrmApplicationDbContext Create()
        {
            return new CrmApplicationDbContext();
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
            modelBuilder.Configurations.Add(new EcpReformatEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}