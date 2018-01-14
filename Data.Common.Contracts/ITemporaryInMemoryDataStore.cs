namespace Data.Common.Contracts
{
    public interface ITemporaryInMemoryDataStore<TKey, TEntity> where TEntity : class
    {
        void AppendForInserting(TEntity entity);

        void AppendForRemoving(TKey key);
    }
}
