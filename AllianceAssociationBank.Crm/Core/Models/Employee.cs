using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(15)]
        public string ZipCode { get; set; }
    }
}