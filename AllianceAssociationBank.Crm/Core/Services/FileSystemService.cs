using AllianceAssociationBank.Crm.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Core.Services
{
    public class FileSystemService : IFileSystemService
    {
        public string GetAppBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public bool IsFileExists(string path)
        {
            return System.IO.File.Exists(path);
        }
    }
}