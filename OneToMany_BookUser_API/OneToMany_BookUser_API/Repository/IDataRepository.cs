namespace OneToMany_BookUser_API.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity,TEntity entity1);
        void Delete(TEntity entity);

    }
}
