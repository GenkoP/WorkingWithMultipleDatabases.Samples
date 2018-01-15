namespace Utility.Contracts
{
    public interface IConfigurationProvider
    {
        string GetAppSetting(string key);

        string GetConnectionString(string connectionStringName);
    }
}
