namespace BAL.Repository
{
    public interface IMainRepositoryNew<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
    }
}
