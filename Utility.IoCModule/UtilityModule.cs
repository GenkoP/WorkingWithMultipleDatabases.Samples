using SimpleInjector;
using SimpleInjector.Packaging;
using Utility.Contracts;
using Utility.Implementation;

namespace Utility.IoCModule
{
    public sealed class UtilityModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterCollection<IInitializer>();
            container.Register<IConfigurationProvider, AppConfigurationProvider>();
        }
    }
}
