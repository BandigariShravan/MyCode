using Microsoft.EntityFrameworkCore;
using OneToMany_BookUser_API.Data;
using OneToMany_BookUser_API.Models;
using OneToMany_BookUser_API.Repository;

namespace OneToMany_BookUser_API.DataManager
{
    public class BookManager : IDataRepository<Book>
    {
        private BookUserDBContext BookUserDBContext;
        public BookManager(BookUserDBContext _bookUserDBContext)
        {
            BookUserDBContext = _bookUserDBContext;
        }
        public void Delete(Book entity)
        {
            BookUserDBContext.Books.Remove(entity);
            BookUserDBContext.SaveChanges();
        }

        public Book Get(int id)
        {
            var Record = BookUserDBContext.Books.Find(id);
            return Record;
        }

        public IEnumerable<Book> GetAll()
        {
            return BookUserDBContext.Books.ToList();
        }

        public void Insert(Book book)
        {
            var entity = new Book
            {
                Book_Name = book.Book_Name,
                Author = book.Author,
                Published_Time = book.Published_Time,
                ISBN = book.ISBN
            };
            BookUserDBContext.Add(entity);
            BookUserDBContext.SaveChanges();
        }

        public void Update(Book entity, Book entity1)
        {
            entity.Book_Name = entity1.Book_Name;
            entity.Author = entity1.Author;
            entity.Published_Time= entity1.Published_Time;
            entity.ISBN = entity1.ISBN;
            BookUserDBContext.SaveChanges();
        }
    }
}
