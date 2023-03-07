namespace JWT_Authentication_NewAPI.Repository
{
    public interface IDataRepository<TEntity>
    {
      
        TEntity Get(int id);
        void Add(TEntity NewStudent);
        void Update(TEntity student,TEntity entity);
        void Delete(int id);
    }
}
