using Moq;
using UnitTesting_Final.Controllers;
using UnitTesting_Final.DataRepository;
using UnitTesting_Final.Models;

namespace UnitTestProject
{
    public class UnitTestContoller
    {
        private readonly Mock<IDataRepository> repo;
        public UnitTestContoller()
        {
            repo = new Mock<IDataRepository>();
        }
        [Fact]
        public void GetProductList_ProductList()
        {
            //arrange
            var productList = GetProductData();
            repo.Setup(x=>x.GetAllProducts()).Returns(productList);
            var productController=new ProductController(repo.Object);

            //act
            var productResult = productController.Get();

            //assert
            Assert.NotNull(productResult);
            //Assert.Equal(GetProductData().Count(), productResult.Count());
            Assert.Equal(GetProductData().ToString(), productResult.ToString());
            Assert.True(productList.Equals(productResult));

        }

        private List<Product> GetProductData()
            //Listing Products
        {
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    Product_Id= 2,
                    Product_Name="Redmi",
                    Product_Description="Mobile Phone",
                    Product_Price="25000",
                    Product_Stock=22
                },
                new Product
                {
                    Product_Id= 8,
                    Product_Name="iiii",
                    Product_Description="Mobile_Phone",
                    Product_Price="19000",
                    Product_Stock=5
                }
            };
            return products;
        }

        [Fact]
        public void GetProductByID_Product()
        {
            //arrange
            var productlist=GetProductData();
            repo.Setup(x => x.Get(1)).Returns(productlist[0]);
            var productController=new ProductController(repo.Object);

            //act
            var productResult = productController.Get(1);

            //assert\
            Assert.NotNull(productResult);
            Assert.Equal(productlist[0].Product_Id, productResult.Product_Id);
            Assert.True(productlist[0].Product_Id== productResult.Product_Id);
            
        }
    }
}