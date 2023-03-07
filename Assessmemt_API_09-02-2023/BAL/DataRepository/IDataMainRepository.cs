namespace BAL.DataRepository
{
    public interface IDataMainRepository<TEntity>
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Insert(TEntity entity);
        Task Update(TEntity entity,TEntity entity1);
        Task Delete(TEntity entity);
    }
}