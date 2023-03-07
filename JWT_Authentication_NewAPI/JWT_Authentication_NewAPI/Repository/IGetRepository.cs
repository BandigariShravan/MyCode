namespace JWT_Authentication_NewAPI.Repository
{
    public interface IGetRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
