using Data.SQL.Common.Contracts;
using Data.SQL.Dapper.Implementation;
using Data.SQL.SQLite.Implementation;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Packaging;
using Utility.Contracts;

namespace Data.SQL.Dapper.SQLite.IoCModule
{
    public sealed class DataDapperSQLiteModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IDataCommandExecuter>(() =>
            {
                IConfigurationProvider configurationProvider = container.GetInstance<IConfigurationProvider>();
                string connectionString = configurationProvider.GetConnectionString("SQLiteTestMultipleDb");
                return new DataCommandExecuter(connectionString);
             });

            container.AppendToCollection(typeof(IInitializer), typeof(SQLiteInitializer));
        }
    }
}
