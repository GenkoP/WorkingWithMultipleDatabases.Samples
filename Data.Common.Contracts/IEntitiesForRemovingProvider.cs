using System.Collections.Generic;

namespace Data.Common.Contracts
{
    public interface IEntitiesForRemovingProvider<TKey, TEntity> where TEntity : class
    {
        IEnumerable<TKey> GetAllEntitiesForRemoving();
    }
}
