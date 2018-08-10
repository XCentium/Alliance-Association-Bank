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
        }
    }
}