namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface IFileSystemService
    {
        string GetAppBaseDirectory();
        bool IsFileExists(string path);
    }
}