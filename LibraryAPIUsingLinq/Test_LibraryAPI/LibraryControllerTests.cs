using LibraryAPI.Controllers;
using LibraryAPIUsingLinq.DataManager;
using LibraryAPIUsingLinq.Models;
using LibraryAPIUsingLinq.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Test_LibraryAPI
{
    public class LibraryControllerTests
    {
        private readonly Mock<IDataRepository<Library>> _libraryRepository = new Mock<IDataRepository<Library>>();
        [Fact]
        public void GetAllLibrary_Returns_404_IfClassNotFound()
        {
            //Arrange
            var library = new Mock<IDataRepository<Library>>();
            //Act
            library.Setup(repo => repo.GetLib(It.IsAny<int>())).Returns((int Id) => new Library { id = Id, Author = "string" });
            //Assert
            //var result = await CreateObjectUnderTest().GetLib(400, library.Object);
            var result = CreateObjectUnderTest();
            Assert.NotNull(result);
            Assert.IsAssignableFrom<Library>(result);
            Assert.Equal(library.Object, result);
        }

        private LibraryController CreateObjectUnderTest()
        {
            return new LibraryController(_libraryRepository: _libraryRepository.Object);
        }

        


        //private readonly IDataRepository<Library> _libraryRepository;
        //private readonly LibraryController _controller;

        //public LibraryControllerTests()
        //{
        //    // Set up mock repository
        //    var mockRepo = new Mock<IDataRepository<Library>>();
        //    mockRepo.Setup(repo => repo.GetLib(It.IsAny<int>()))
        //        .ReturnsAsync((int Id) => new Library { id = Id, Author = "Test Library" });

        //    _libraryRepository = mockRepo.Object;

        //    // Set up controller
        //    _controller = new LibraryController(_libraryRepository);
        //}

        //[Fact]
        //public async void GetLibrary_ReturnsCorrectObject()
        //{
        //    // Act
        //    var result = await _controller.GetLib(3);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    var objectResult = result as OkObjectResult;
        //    Assert.IsType<Library>(objectResult.Value);
        //    var library = objectResult.Value as Library;
        //    Assert.Equal(1, library.id);
        //    Assert.Equal("Test Library", library.Author);
        //}

    }
}