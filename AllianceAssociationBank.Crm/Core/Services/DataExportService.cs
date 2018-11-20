using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using CsvHelper;
using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.Extensions;

namespace AllianceAssociationBank.Crm.Core.Services
{
    public class DataExportService : IDataExportService
    {
        private const string CSV_CONTENT_TYPE = "text/csv";

        private IReportQueries _queries;

        public DataExportService(IReportQueries queries)
        {
            _queries = queries;
        }

        public async Task<FileStreamResult> GenerateExportFileByName(string exportName)
        {
            var dataSource = await GetDataSourceByName(exportName);

            if (dataSource == null)
            {
                return null;
            }

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            var csvWriter = new CsvWriter(streamWriter);

            csvWriter.Configuration.RegisterClassMap(GetCsvMapByName(exportName));
            csvWriter.WriteRecords(dataSource);
            streamWriter.Flush();
            memoryStream.Position = 0;

            var exportFile = new FileStreamResult(memoryStream, CSV_CONTENT_TYPE);
            exportFile.FileDownloadName = $"{exportName}.csv";

            return exportFile;
        }

        private async Task<IEnumerable> GetDataSourceByName(string exportName)
        {
            switch (exportName)
            {
                case var name when name.EqualsIgnoreCase(ExportName.CmcList):
                    {
                        return await _queries.GetCmcByIdDataSetAsync();
                    }
                case var name when name.EqualsIgnoreCase(ExportName.CmcUsefulInfoList):
                    {
                        return await _queries.GetCmcByIdDataSetAsync();
                    }
                case var name when name.EqualsIgnoreCase(ExportName.AllInfo):
                    {
                        return await _queries.GetAllInfoDataSetAsync();
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        private Type GetCsvMapByName(string exportName)
        {
            switch (exportName)
            {
                case var name when name.EqualsIgnoreCase(ExportName.CmcList):
                    {
                        return typeof(CmcListExportMap);
                    }
                case var name when name.EqualsIgnoreCase(ExportName.CmcUsefulInfoList):
                    {
                        return typeof(CmcUsefulInfoListExportMap);
                    }
                case var name when name.EqualsIgnoreCase(ExportName.AllInfo):
                    {
                        return typeof(AllInfoExportMap);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}