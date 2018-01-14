using System.Collections.Generic;
using Data.Common.Contracts;

namespace Data.Common.Implementation
{
    public sealed class TemporaryInMemoryDataStore<TKey, TEntity>
        : ITemporaryInMemoryDataStore<TKey, TEntity>, ICleanable
        , IEntitiesForInsertingProvider<TEntity>, IEntitiesForRemovingProvider<TKey,TEntity>
        where TEntity : class
    {
        private readonly ICollection<TKey> keysForRemove;
        private readonly ICollection<TEntity> entitiesForInsertion;

        public TemporaryInMemoryDataStore()
        {
            keysForRemove = new HashSet<TKey>();
            entitiesForInsertion = new List<TEntity>();
        }

        public IEnumerable<TEntity> GetAllEntitiesForInserting()
        {
            return this.entitiesForInsertion;
        }

        public IEnumerable<TKey> GetAllEntitiesForRemoving()
        {
            return this.keysForRemove;
        }

        public void AppendForInserting(TEntity entity)
        {
            this.entitiesForInsertion.Add(entity);
        }

        public void AppendForRemoving(TKey key)
        {
            this.keysForRemove.Add(key);
        }

        public void Clean()
        {
            this.keysForRemove.Clear();
            this.entitiesForInsertion.Clear();
        }
    }
}
