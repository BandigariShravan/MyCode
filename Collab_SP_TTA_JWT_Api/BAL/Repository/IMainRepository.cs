namespace BAL.Repository
{
    public interface IMainRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
    }
}
