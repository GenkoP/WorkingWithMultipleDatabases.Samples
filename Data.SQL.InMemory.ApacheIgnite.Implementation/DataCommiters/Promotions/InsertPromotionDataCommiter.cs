using System;
using System.Collections.Generic;
using System.Linq;
using Apache.Ignite.Core.Cache;
using Data.Common.Contracts;
using Data.Models;

namespace Data.SQL.InMemory.ApacheIgnite.Implementation.DataCommiters.Promotions
{
    public sealed class InsertPromotionDataCommiter : IDataCommiter
    {
        private readonly IgniteAdapter igniteAdapter;
        private readonly IEntitiesForInsertingProvider<Promotion> promotionsProvider;

        public InsertPromotionDataCommiter(IgniteAdapter igniteAdapter, IEntitiesForInsertingProvider<Promotion> promotionsProvider)
        {
            this.igniteAdapter = igniteAdapter ?? throw new ArgumentNullException($"{nameof(igniteAdapter)} should not be null");
            this.promotionsProvider = promotionsProvider ?? throw new ArgumentNullException($"{nameof(promotionsProvider)} should not be null");
        }

        public void Commit()
        {
            IDictionary<Guid, Promotion> users = this.promotionsProvider.GetAllEntitiesForInserting().ToDictionary(x => x.Id);

            if (users.Count > 0)
            {
                ICache<Guid, Promotion> promotionCache = igniteAdapter.GetOrCreateCache<Guid, Promotion>(nameof(Promotion));
                promotionCache.PutAll(users);
            }
        }
    }
}
