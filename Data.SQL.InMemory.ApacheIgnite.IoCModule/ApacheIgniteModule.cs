using Data.SQL.InMemory.ApacheIgnite.Implementation;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.SQL.InMemory.ApacheIgnite.IoCModule
{
    public sealed class ApacheIgniteModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IgniteAdapter>();
        }
    }
}
