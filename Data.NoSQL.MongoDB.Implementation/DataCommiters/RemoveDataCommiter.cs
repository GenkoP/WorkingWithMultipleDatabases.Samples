using System;
using System.Collections.Generic;
using System.Linq;
using Data.Common.Contracts;
using Data.Models;
using MongoDB.Driver;

namespace Data.NoSQL.MongoDB.Implementation.DataCommiters
{
    public sealed class RemoveDataCommiter<TKey, TEntity> : IDataCommiter where TEntity : class, IEntityKey<TKey>
    {
        private readonly MongoDbConnection mongoDbConnection;
        private readonly IEntitiesForRemovingProvider<TKey, TEntity> entitiesProvider;

        public RemoveDataCommiter(MongoDbConnection mongoDbConnection, IEntitiesForRemovingProvider<TKey, TEntity> entitiesProvider)
        {
            this.mongoDbConnection = mongoDbConnection ?? throw new ArgumentNullException($"{nameof(mongoDbConnection)} should not be null");
            this.entitiesProvider = entitiesProvider ?? throw new ArgumentNullException($"{nameof(entitiesProvider)} should not be null");
        }

        public void Commit()
        {
            ICollection<TKey> entityIds = this.entitiesProvider.GetAllEntitiesForRemoving().ToList();
            if (entityIds.Count > 0)
            {
                IMongoCollection<TEntity> usersCollection = this.mongoDbConnection.GetCollection<TEntity>(typeof(TEntity).Name);
                usersCollection.DeleteMany(entity => entityIds.Contains(entity.Id));
            }
        }
    }
}
