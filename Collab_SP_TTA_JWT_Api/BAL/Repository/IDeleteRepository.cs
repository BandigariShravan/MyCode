namespace BAL.Repository
{
    public interface IDeleteRepository<TEntity>
    {
        void Delete(TEntity entity);
    }
}
