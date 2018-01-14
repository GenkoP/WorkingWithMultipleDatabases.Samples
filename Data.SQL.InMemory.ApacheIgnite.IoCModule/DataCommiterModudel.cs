using System;
using Data.Common.Contracts;
using Data.Common.Implementation;
using Data.Models;
using Data.SQL.InMemory.ApacheIgnite.Implementation.DataCommiters.Promotions;
using Data.SQL.InMemory.ApacheIgnite.Implementation.DataCommiters.Users;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.SQL.InMemory.ApacheIgnite.IoCModule
{
    public sealed class DataCommiterModudel : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterCollection<IDataCommiter>(new[]
            {
                typeof(InsertUserDataCommiter),
                typeof(InsertPromotionDataCommiter),
                typeof(RemoveDataCommiter<Guid, User>),
                typeof(RemoveDataCommiter<Guid, Promotion>),
            });

            container.Register<IDataCommiter, DataCommiterComposite>();
        }
    }
}
