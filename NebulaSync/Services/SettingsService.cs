using System;
using System.Configuration;

namespace NebulaSync.Services
{
    public class SettingsService
    {
        public readonly int DishesSyncDelay;
        public readonly int OrdersSyncDelay;
        public readonly Uri Host;
        public readonly Uri SyncDishUri;
        public readonly Uri GetExportOrdersUri;
        public readonly string Token;
        public readonly Uri SetExportedOrdersUri;

        public SettingsService()
        {
            Host = new Uri(ConfigurationManager.AppSettings["Host"]);
            Host = new Uri(ConfigurationManager.AppSettings["Host"]);
            Token = ConfigurationManager.AppSettings["Token"];
            DishesSyncDelay = int.Parse(ConfigurationManager.AppSettings["DishesSyncDelay"]);
            OrdersSyncDelay = int.Parse(ConfigurationManager.AppSettings["OrdersSyncDelay"]);
            SyncDishUri = new Uri($"{Host}{ConfigurationManager.AppSettings["SyncDishUri"]}?token={Token}");
            GetExportOrdersUri = new Uri($"{Host}{ConfigurationManager.AppSettings["GetExportOrdersUri"]}?token={Token}");
            SetExportedOrdersUri = new Uri($"{Host}{ConfigurationManager.AppSettings["SetExportedOrdersUri"]}?token={Token}");
        }
    }
}
