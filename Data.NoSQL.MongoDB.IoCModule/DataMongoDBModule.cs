using Data.NoSQL.MongoDB.Implementation;
using SimpleInjector;
using SimpleInjector.Packaging;
using Utility.Contracts;

namespace Data.NoSQL.MongoDB.IoCModule
{
    public sealed class DataMongoDBModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<MongoDbConnection>(() =>
            {
                IConfigurationProvider configurationProvider = container.GetInstance<IConfigurationProvider>();
                string connectionString = configurationProvider.GetConnectionString("MongoDbTestMultipleDb");
                return new MongoDbConnection(connectionString, "testmultipledb");
            });
        }
    }
}
