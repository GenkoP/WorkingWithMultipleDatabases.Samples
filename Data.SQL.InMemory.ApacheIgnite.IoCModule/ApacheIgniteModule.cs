using Data.SQL.InMemory.ApacheIgnite.Implementation;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Packaging;
using Utility.Contracts;

namespace Data.SQL.InMemory.ApacheIgnite.IoCModule
{
    public sealed class ApacheIgniteModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IgniteAdapter>();
            container.AppendToCollection(typeof(IInitializer), typeof(IgniteInitializer));
        }
    }
}
