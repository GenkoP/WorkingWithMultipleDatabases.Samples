using System;
using Data.Common.Contracts;
using Data.Common.Implementation;
using Data.Models;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.Common.IoCModules
{
    public sealed class TemporaryInMemoryDataStoresModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            Type[] temporaryInMemorydataStoreTypes = new Type[]
            {
                typeof(TemporaryInMemoryDataStore<Guid, User>),
                typeof(TemporaryInMemoryDataStore<Guid, Promotion>),
            };

            container.RegisterCollection<ICleanable>(temporaryInMemorydataStoreTypes);
            container.Register<ICleanable, CleanerComposite>();

            container.Register<ITemporaryInMemoryDataStore<Guid, User>, TemporaryInMemoryDataStore<Guid, User>>();
            container.Register<ITemporaryInMemoryDataStore<Guid, Promotion>, TemporaryInMemoryDataStore<Guid, Promotion>>();

            container.Register<IEntitiesForInsertingProvider<User>, TemporaryInMemoryDataStore<Guid, User>>();
            container.Register<IEntitiesForInsertingProvider<Promotion>, TemporaryInMemoryDataStore<Guid, Promotion>>();

            container.Register<IEntitiesForRemovingProvider<Guid, User>, TemporaryInMemoryDataStore<Guid, User>>();
            container.Register<IEntitiesForRemovingProvider<Guid, Promotion>, TemporaryInMemoryDataStore<Guid, Promotion>>();
        }
    }
}
