using System;
using Data.Common.Contracts;
using Data.Common.Implementation;
using Data.Models;
using Data.SQL.Common.Implementation;
using Data.SQL.InMemory.ApacheIgnite.Implementation.DataCommiters.Promotions;
using Data.SQL.InMemory.ApacheIgnite.Implementation.DataCommiters.Users;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.SQL.Combinations.ApacheIgniteAndEF.IoCModule
{
    public sealed class DataCommitersModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterCollection<IDataCommiter>(new[]
            {
                typeof(InsertUserDataCommiter),
                typeof(InsertPromotionDataCommiter),
                typeof(RemoveDataCommiter<Guid, User>),
                typeof(RemoveDataCommiter<Guid, Promotion>),
                typeof(DataCommiter)
            });

            container.Register<IDataCommiter, DataCommiterComposite>();
        }
    }
}
