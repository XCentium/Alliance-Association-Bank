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
                //.MinimumLevel.Information()
                //.WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}