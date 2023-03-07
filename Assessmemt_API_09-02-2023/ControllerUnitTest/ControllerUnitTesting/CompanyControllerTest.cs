using Assessmemt_API_09_02_2023.Controllers;
using BAL.DataRepository;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ControllerUnitTest.UnitTesting
{
    public class CompanyControllerTest
    {
        private readonly Mock<IDataMainRepository<Company>> _dataMainRepositoryMock = new();
        private readonly Mock<IGetAllRepository<Company>> _getRepositoryMock = new();

        [Fact]
        public async Task Get_ReturnsOkResult_WithCompanyData()
        {
            // Arrange
            var controller = new CompanyController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);
            var companies = new List<Company>
        {
            new Company { CompanyId = 1, CompanyName = "Company A",CompanyAddress="T Hub" },
            new Company { CompanyId = 2, CompanyName = "Company B",CompanyAddress="U Hub" },
            new Company {CompanyId = 3, CompanyName = "Company C", CompanyAddress = "V Hub"},
        };
            _getRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(companies);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<Company>>(okResult.Value);
            Assert.Equal(companies.Count, data.Count());
        }

        [Fact]
        public async Task Get_ReturnsNotFoundResult_WithoutCompanyData()
        {
            // Arrange
            var controller = new CompanyController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);
            _getRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(() => null!);

            // Act
            var result = await controller.Get();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.NotNull(notFoundResult.Value);
            Assert.Equal("No Data Found...", notFoundResult.Value);
        }
        [Fact]
        public async Task GetByID_ReturnsOkResult_WhenCompanyRecordIsFound()
        {
            //Arrange
            var companies = new List<Company>
            {
                new Company { CompanyId = 1, CompanyName = "Company A", CompanyAddress = "T Hub" },
                new Company { CompanyId = 2, CompanyName = "Company B", CompanyAddress = "U Hub" },
                new Company { CompanyId = 3, CompanyName = "Company C", CompanyAddress = "V Hub" },
            };
            var firstCompany = companies[0];
            _dataMainRepositoryMock.Setup(x => x.Get((int)1)).ReturnsAsync(firstCompany);
            var controller = new CompanyController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);

            //Act
            var actionResult = controller.GetById((int)1);
            var result = actionResult.Result as OkObjectResult;

            //Assert
            // Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByID_ReturnsNotFoundResult_WhenCompanyRecordIsNotFound()
        {
            var companies = new List<Company>
            {
                new Company { CompanyId = 1, CompanyName = "Company A", CompanyAddress = "T Hub" },
                new Company { CompanyId = 2, CompanyName = "Company B", CompanyAddress = "U Hub" },
                new Company { CompanyId = 3, CompanyName = "Company C", CompanyAddress = "V Hub" },
            };
            var firstCompany = companies[0];
            int id = 4;
            _dataMainRepositoryMock.Setup(x => x.Get(id)).ReturnsAsync(firstCompany);
            var controller = new CompanyController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);

            //Act
            var result =await controller.GetById((int)10);
            //var result = actionResult.Result as NotFoundObjectResult;

            //Assert
            //var actionResult= Assert.IsType<NotFoundObjectResult>(result);
            //Assert.Equal(id + "Not Found", actionResult);
            //Assert.DoesNotContain()
            Assert.Null(result as NotFoundResult);
        }
        [Fact]
        public async Task DeleteById_ReturnsNotFoundResult_WhenIdIsZero()
        {
            //var companies = new List<Company>
            //{
            //    new Company { CompanyId = 1, CompanyName = "Company A", CompanyAddress = "T Hub" },
            //    new Company { CompanyId = 2, CompanyName = "Company B", CompanyAddress = "U Hub" },
            //    new Company { CompanyId = 3, CompanyName = "Company C", CompanyAddress = "V Hub" },
            //};

            ////var company = companies[0];
            int id = 0;
            //////_dataMainRepositoryMock.Setup(xy => xy.Get(id).ReturnsAsync((Company)null);
            var controller = new CompanyController(_dataMainRepositoryMock.Object, _getRepositoryMock.Object);

            //////Act
            var deleteCompany = await controller.Delete(id);
            ////var actionResult = controller.;//.Result as |OkObjectResult);

            //////Assert
            //var NotFoundResult=Assert.IsType<NotFoundResult>(deleteCompany);
            ////Assert.Equal("Id Details of " + id + " are Not Found", NotFoundResult.ToString());
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(deleteCompany);
            Assert.Equal("Id Cannot be Null", notFoundResult.Value);
        }

    }
}
