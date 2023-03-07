using UnitTesting_Final.Data;
using UnitTesting_Final.DataRepository;
using UnitTesting_Final.Models;

namespace UnitTesting_Final.DataManager
{
    public class ProductManager : IDataRepository 
    {
        private readonly ProductDbContext _dbContextClass;
        public ProductManager(ProductDbContext dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }
        public void Insert(Product entity)
        {
            var AddingProduct = new Product
            {
                Product_Name = entity.Product_Name,
                Product_Description = entity.Product_Description,
                Product_Price = entity.Product_Price,
                Product_Stock = entity.Product_Stock
            };
            _dbContextClass.Add(AddingProduct);
            _dbContextClass.SaveChanges();
        }
        public void Delete(int id)
        {
            var value = _dbContextClass.Products.Find(id);
            _dbContextClass.Products.Remove(value);
        }
        public Product Get(int id)
        {
            var value = _dbContextClass.Products.Find(id);
            return value;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContextClass.Products.ToList();
        }
        public void Update(Product entity, Product entity1)
        {
            entity.Product_Name = entity1.Product_Name;
            entity.Product_Description= entity1.Product_Description;
            entity.Product_Price = entity1.Product_Price;
            entity.Product_Stock = entity1.Product_Stock;
            _dbContextClass.SaveChanges();
        }
    }
}
