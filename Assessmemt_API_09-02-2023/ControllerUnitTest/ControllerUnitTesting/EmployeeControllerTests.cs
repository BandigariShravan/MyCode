using Assessmemt_API_09_02_2023.Controllers;
using BAL.DataRepository;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ControllerUnitTest.UnitTesting
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IDataMainRepository<Employee>> _dataMainRepositoryMock = new();
        private readonly Mock<IGetAllRepository<Employee>> _getRepositoryMock = new();

        [Fact]
        public async Task Get_ReturnsOkResult_WithEmployeeData()
        {
            // Arrange
            var controller = new EmployeeController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);
            var employees = new List<Employee>
            {
            new Employee { EmployeeeId = 1, EmployeeName = "Employee A",Salary=20000,CompanyId=1 },
            new Employee { EmployeeeId = 2, EmployeeName = "Employee B",Salary=10000,CompanyId = 2 },
            new Employee {EmployeeeId = 3, EmployeeName = "Employee C", Salary = 15000, CompanyId = 3},
            };
            _getRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(employees);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<Employee>>(okResult.Value);
            Assert.Equal(employees.Count, data.Count());
        }

        [Fact]
        public async Task Get_ReturnsNotFoundResult_WithoutEmployeeData()
        {
            // Arrange
            var controller = new EmployeeController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);
            _ = _getRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(() => null!);

            // Act
            var actionResult = await controller.Get();
            //var result = actionResult.ExecuteResultAsync;

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult);
        }
        [Fact]
        public async Task GetByID_ReturnsOkResult_WhenEmployeeRecordIsFound()
        {
            //Arrange
            var employees = new List<Employee>
            {
            new Employee { EmployeeeId = 1, EmployeeName = "Employee A",Salary=20000,CompanyId=1 },
            new Employee { EmployeeeId = 2, EmployeeName = "Employee B",Salary=10000,CompanyId = 2 },
            new Employee {EmployeeeId = 3, EmployeeName = "Employee C", Salary = 15000, CompanyId = 3},
            };
            var firstCompany = employees[0];
            _dataMainRepositoryMock.Setup(x => x.Get((int)1)).ReturnsAsync(firstCompany);
            var controller = new EmployeeController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);

            //Act
            var actionResult = controller.GetById((int)1);
            var result = actionResult.Result as OkObjectResult;

            //Assert
            // Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByID_ReturnsNotFoundResult_WhenEmployeeRecordIsNotFound()
        {
            var employees = new List<Employee>
            {
            new Employee { EmployeeeId = 1, EmployeeName = "Employee A",Salary=20000,CompanyId=1 },
            new Employee { EmployeeeId = 2, EmployeeName = "Employee B",Salary=10000,CompanyId = 2 },
            new Employee {EmployeeeId = 3, EmployeeName = "Employee C", Salary = 15000, CompanyId = 3},
            };
            var firstEmployee = employees[0];
            _dataMainRepositoryMock.Setup(x => x.Get((int)1)).ReturnsAsync(firstEmployee);
            var controller = new EmployeeController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);

            //Act
            var actionResult = controller.GetById((int)10);
            var result = actionResult.Result as NotFoundObjectResult;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}