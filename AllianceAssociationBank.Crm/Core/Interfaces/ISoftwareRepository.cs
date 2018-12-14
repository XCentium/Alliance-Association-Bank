using AllianceAssociationBank.Crm.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface ISoftwareRepository
    {
        Task<IEnumerable<Software>> GetSoftwareAsync();
        Task<Software> GetSoftwareByIdAsync(int id);
        Task<Software> GetSoftwareByNameAsync(string softwareName);
        Task<int> GetCountOfAssociatedActiveProjects(int id);
        void AddSoftware(Software software);
        void RemoveSoftware(Software software);
        Task<bool> SaveAllAsync();
    }
}