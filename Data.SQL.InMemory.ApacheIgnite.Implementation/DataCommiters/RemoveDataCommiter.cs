using System;
using System.Collections.Generic;
using System.Linq;
using Apache.Ignite.Core.Cache;
using Data.Common.Contracts;

namespace Data.SQL.InMemory.ApacheIgnite.Implementation.DataCommiters.Promotions
{
    public sealed class RemoveDataCommiter<TKey, TEntity> : IDataCommiter where TEntity : class
    {
        private readonly IgniteAdapter igniteAdapter;
        private readonly IEntitiesForRemovingProvider<TKey, TEntity> entityIdsProvider;

        public RemoveDataCommiter(IgniteAdapter igniteAdapter, IEntitiesForRemovingProvider<TKey, TEntity> entityIdsProvider)
        {
            this.igniteAdapter = igniteAdapter ?? throw new ArgumentNullException($"{nameof(igniteAdapter)} should not be null");
            this.entityIdsProvider = entityIdsProvider ?? throw new ArgumentNullException($"{nameof(entityIdsProvider)} should not be null");
        }

        public void Commit()
        {
            ICollection<TKey> entityIds = this.entityIdsProvider.GetAllEntitiesForRemoving().ToList();

            if (entityIds.Count > 0)
            {
                ICache<TKey, TEntity> promotionCache = this.igniteAdapter.GetOrCreateCache<TKey, TEntity>(typeof(TEntity).Name);
                promotionCache.RemoveAll(entityIds);
            }
        }
    }
}
