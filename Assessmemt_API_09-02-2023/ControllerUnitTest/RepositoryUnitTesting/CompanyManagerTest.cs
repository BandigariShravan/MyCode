using BAL.DataManager;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace UnitTest.RepositoryUnitTesting
{
    public class CompanyManagerTest
    {
        //private readonly Mock<CompanyDBContext> mockContext;

        //[Fact]
        //public async Task GetAll_ReturnsAllCompanyData()
        //{
        //    //var options = mockContext.Setup;

        //    //using var dbContext = new CompanyDBContext(options);
        //    var employees = new List<Employee>
        //    {
        //    new Employee { EmployeeeId = 1, EmployeeName = "Employee A",Salary=20000,CompanyId=1 },
        //    new Employee { EmployeeeId = 2, EmployeeName = "Employee B",Salary=10000,CompanyId = 2 },
        //    new Employee {EmployeeeId = 3, EmployeeName = "Employee C", Salary = 15000, CompanyId = 3},
        //    };

        //    var service = new CompanyManager(mockContext.Object);

        //    // Act
        //    var result = await service.GetAll();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(4, result.Count());
        //}

        private readonly CompanyManager _manager;
        public CompanyManagerTest()
        {
            var mockDBContext = new Mock<CompanyDBContext>();
            mockDBContext.Setup(y => y.Companies).Returns(Mock.Of<DbSet<Company>>());
            _manager=new CompanyManager(mockDBContext.Object);
        }
        [Fact]
        public async Task GetAll_ShouldReturnsCompaniesRecords()
        {
            //Arrange
            //var employees = new List<Employee>
            //{
            //new Employee { EmployeeeId = 1, EmployeeName = "Employee A",Salary=20000,CompanyId=1 },
            //new Employee { EmployeeeId = 2, EmployeeName = "Employee B",Salary=10000,CompanyId = 2 },
            //new Employee {EmployeeeId = 3, EmployeeName = "Employee C", Salary = 15000, CompanyId = 3},
            //};
            var companies = new List<Company>
        {
            new Company { CompanyId = 1, CompanyName = "Aqit",CompanyAddress = "hub" },
            new Company { CompanyId = 2, CompanyName = "TCS",CompanyAddress = "Hyderabad" }
        };
           // await _manager.Insert(companies);
            var result=await _manager.GetAll();
            Assert.NotNull(result);
            var resultList=result.ToList();
            Assert.Equal(2, resultList.Count);
        }
    }
}
