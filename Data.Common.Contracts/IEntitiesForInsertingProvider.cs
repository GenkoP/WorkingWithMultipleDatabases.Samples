using System.Collections.Generic;

namespace Data.Common.Contracts
{
    public interface IEntitiesForInsertingProvider<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllEntitiesForInserting();
    }
}
