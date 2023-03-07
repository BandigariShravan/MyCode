namespace BAL.DataRepository
{
    public interface IGetAllRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
    }
}