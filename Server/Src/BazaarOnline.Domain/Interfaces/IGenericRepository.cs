namespace BazaarOnline.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity? Get(int id);

        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void UpdateRange(IEnumerable<TEntity> entities);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Save();
    }
}
