using System.Reflection;
using Data.SQL.Common.Contracts;
using Data.SQL.Common.Implementation.CommandBuilders;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.SQL.Common.IoCModule
{
    public sealed class CommanBuildersModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            Assembly assembly = typeof(CommandBuilderComposite).Assembly;
            container.RegisterCollection<ICommandBuilder>(new[] { assembly });
            container.Register<ICommandBuilder, CommandBuilderComposite>();
        }
    }
}
