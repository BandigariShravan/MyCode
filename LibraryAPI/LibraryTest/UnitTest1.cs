//using LibraryAPI.Controllers;
//using LibraryAPI.Data;
//using LibraryAPI.Models;
//using Moq;

//namespace LibraryTest
//{
//    public class UnitTest1
//    {
//        [Fact]
//        public void Get_ReturnCorrectLibraraies()
//        {
//            var libraraies = new List<Library>
//            {
//                new Library { id = 1, Title = "Aditya 369", Author = "nadela raju", Publisher = "mounika", Publication_Year = 1485, Genre = "time-travel", ISBN = "789456", Number_Of_Pages = 114 }
//            };

//            var mockContext=new Mock<LibraryAPIDBContext>();
//            mockContext.Setup(x => x.Libraries1).Returns(libraraies);

//            var controller=new LibraryController(mockContext.Object);
//        }
//    }
//}