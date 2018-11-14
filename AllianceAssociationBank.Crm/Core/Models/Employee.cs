using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string Company { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}