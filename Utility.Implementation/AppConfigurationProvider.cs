using System.Configuration;
using Utility.Contracts;

namespace Utility.Implementation
{
    public class AppConfigurationProvider : IConfigurationProvider
    {
        public string GetConnectionString(string connectionStringName)
        {
           return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
