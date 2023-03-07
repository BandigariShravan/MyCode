using UnitTesting_Final.Models;

namespace UnitTesting_Final.DataRepository
{
    public interface IDataRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product Get(int id);
        void Insert(Product entity);
        void Update(Product entity, Product entity1);
        void Delete(int id);
    }
}
