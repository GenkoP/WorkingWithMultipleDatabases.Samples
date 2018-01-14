using Data.SQL.Common.Contracts;
using Data.SQL.EF.Implementation;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.SQL.EF.IoCModules
{
    public sealed class DataEntityFrameworkModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<DataContext>(() => new DataContext("MSQLTestMultipleDb"));
            container.Register<IDataCommandExecuter, DataCommandExecuter>();
        }
    }
}
