using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IDataExportService
    {
        Task<FileStreamResult> GenerateExportFileByName(string exportName);
    }
}