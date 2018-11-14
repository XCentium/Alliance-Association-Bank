using AllianceAssociationBank.Crm.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace AllianceAssociationBank.Crm.Persistence.EntityConfigurations
{
    public class EmployeeEntityConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeEntityConfiguration()
        {
            ToTable("Employees");

            HasKey(e => e.ID);

            Property(e => e.Company)
                .HasMaxLength(50);

            Property(e => e.LastName)
                .HasMaxLength(50);

            Property(e => e.FirstName)
                .HasMaxLength(50);

            Property(e => e.City)
                .HasMaxLength(50);

            Property(e => e.State)
                .HasMaxLength(50);

            Property(e => e.ZipCode)
                .HasMaxLength(15);
        }
    }
}