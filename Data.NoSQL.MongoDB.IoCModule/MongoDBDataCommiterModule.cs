using System;
using Data.Common.Contracts;
using Data.Common.Implementation;
using Data.Models;
using Data.NoSQL.MongoDB.Implementation.DataCommiters;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Data.NoSQL.MongoDB.IoCModule
{
    public sealed class MongoDBDataCommiterModule : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.RegisterCollection<IDataCommiter>(new[]
            {
                typeof(InsertDataCommiter<User>),
                typeof(InsertDataCommiter<Promotion>),
                typeof(RemoveDataCommiter<Guid, User>),
                typeof(RemoveDataCommiter<Guid, Promotion>)
            });

            container.Register<IDataCommiter, DataCommiterComposite>();
        }
    }
}
