using Data.Common.Contracts;
using Data.Common.Implementation;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.Common.IoCModules
{
    public sealed class DataCommiterCleanerDecoratorModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterDecorator<IDataCommiter, DataCommiterCleanerDecorator>();
        }
    }
}
