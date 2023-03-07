namespace BAL.Repository
{
    public interface IUpdateRepository<TEntity>
    {
        void Update(TEntity entity, TEntity entity1);
    }
}
