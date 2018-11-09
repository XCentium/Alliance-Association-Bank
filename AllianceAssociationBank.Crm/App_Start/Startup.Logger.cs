using Serilog;
using System;

namespace AllianceAssociationBank.Crm
{
    public partial class Startup
    {
        public void ConfigureLogger()
        {
            var appBaseDir = AppDomain.CurrentDomain.BaseDirectory;
            Environment.SetEnvironmentVariable("APPBASEDIR", appBaseDir);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings(filePath: $"{appBaseDir}\\LoggerSettings.config")
                .CreateLogger();
        }
    }
}