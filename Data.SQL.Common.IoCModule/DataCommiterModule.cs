using Data.Common.Contracts;
using Data.SQL.Common.Implementation;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.SQL.Common.IoCModule
{
    public sealed class DataCommiterModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IDataCommiter, DataCommiter>();
        }
    }
}
