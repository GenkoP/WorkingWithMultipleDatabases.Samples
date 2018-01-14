using System;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.Cache.Configuration;
using Data.Models;

namespace Data.SQL.InMemory.ApacheIgnite.Implementation
{
    public sealed class IgniteAdapter
    {
        private IIgnite ignite;

        public void IgnitionStart()
        {
            ignite = Ignition.Start();

            QueryEntity userQueryEntity = new QueryEntity
            {
                KeyType = typeof(Guid),
                ValueType = typeof(User),
                Fields = new[]
               {
                    new QueryField {Name = nameof(User.Username), FieldType = typeof(string)},
                    new QueryField {Name = nameof(User.Password), FieldType = typeof(string)},
                    new QueryField {Name = nameof(User.Email), FieldType = typeof(string)}
                }
            };

            ignite.GetOrCreateCache<int, User>(new CacheConfiguration
            {
                Name = nameof(User),
                QueryEntities = new[]
                {
                    userQueryEntity
                }
            });

            QueryEntity promotionQueryEntity = new QueryEntity
            {
                KeyType = typeof(Guid),
                ValueType = typeof(Promotion),
                Fields = new[]
                {
                    new QueryField {Name = nameof(Promotion.Name), FieldType = typeof(string)},
                    new QueryField {Name = nameof(Promotion.CategoryName), FieldType = typeof(string)},
                }
            };

            ignite.GetOrCreateCache<int, Promotion>(new CacheConfiguration
            {
                Name = nameof(Promotion),
                QueryEntities = new[]
                {
                    promotionQueryEntity
                }
            });
        }

        public ICache<TKey, TEntity> GetOrCreateCache<TKey, TEntity>(string cacheName)
        {
            return ignite.GetOrCreateCache<TKey, TEntity>(cacheName);
        }
    }
}
