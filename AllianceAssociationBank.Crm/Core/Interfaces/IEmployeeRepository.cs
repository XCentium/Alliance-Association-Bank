using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> GetEmployeeByNameAsync(string firstName, string lastName);
        Task<int> GetCountOfAssociatedActiveProjects(int id);
        void AddEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        Task<bool> SaveAllAsync();
    }
}