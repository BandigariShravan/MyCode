namespace BAL.Repository
{
    public interface IInsertRepository<TEntity>
    {
        void Insert(TEntity entity);
    }
}
