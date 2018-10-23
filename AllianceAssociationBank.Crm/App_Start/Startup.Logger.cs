using Serilog;
using System;

namespace AllianceAssociationBank.Crm
{
    public partial class Startup
    {
        public void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "/Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
                //.ReadFrom.AppSettings()

            Log.Information("Hello, Serilog!");

        }
    }
}