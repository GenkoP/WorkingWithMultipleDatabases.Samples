using SimpleInjector;
using SimpleInjector.Packaging;
using Utility.Contracts;

namespace Data.Common.IoCModules
{
    public sealed class InitializersModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterCollection<IInitializer>();
        }
    }
}
