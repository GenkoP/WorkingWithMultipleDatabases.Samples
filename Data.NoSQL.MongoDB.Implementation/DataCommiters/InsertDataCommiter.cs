using System;
using System.Collections.Generic;
using System.Linq;
using Data.Common.Contracts;
using MongoDB.Driver;

namespace Data.NoSQL.MongoDB.Implementation.DataCommiters
{
    public sealed class InsertDataCommiter<TEntity> : IDataCommiter where TEntity : class
    {
        private readonly MongoDbConnection entitiesProvider;
        private readonly IEntitiesForInsertingProvider<TEntity> usersProvider;

        public InsertDataCommiter(MongoDbConnection entitiesProvider, IEntitiesForInsertingProvider<TEntity> usersProvider)
        {
            this.entitiesProvider = entitiesProvider ?? throw new ArgumentNullException($"{nameof(entitiesProvider)} should not be null");
            this.usersProvider = usersProvider ?? throw new ArgumentNullException($"{nameof(usersProvider)} should not be null");
        }

        public void Commit()
        {
            ICollection<TEntity> entities = this.usersProvider.GetAllEntitiesForInserting().ToList();

            if (entities.Count > 0)
            {
                IMongoCollection<TEntity> usersCollection = this.entitiesProvider.GetCollection<TEntity>(typeof(TEntity).Name);
                usersCollection.InsertMany(entities);
            }
        }
    }
}
