using Microsoft.EntityFrameworkCore;
using OneToMany_BookUser_API.Data;
using OneToMany_BookUser_API.Models;
using OneToMany_BookUser_API.Repository;

namespace OneToMany_BookUser_API.DataManager
{
    public class UserManager : IDataRepository<User>
    {
        private BookUserDBContext BookUserDBContext;
        public UserManager(BookUserDBContext _bookUserDBContext)
        {
            BookUserDBContext = _bookUserDBContext;
        }
        public void Delete(User entity)
        {
            BookUserDBContext.Users.Remove(entity);
            BookUserDBContext.SaveChanges();
        }

        public User Get(int id)
        {
            var Record = BookUserDBContext.Users.Find(id);
            return Record;
        }

        public IEnumerable<User> GetAll()
        {
            return BookUserDBContext.Users.Include("Book").ToList();
        }

        public void Insert(User user)
        {
            var entity = new User
            {
                Full_Name = user.Full_Name,
                Enabled = user.Enabled,
                Last_Login = user.Last_Login,
                Book_Id = user.Book_Id

            };
            BookUserDBContext.Users.Add(entity);
            BookUserDBContext.SaveChanges();
        }

        public void Update(User entity, User entity1)
        {
            entity.Full_Name = entity1.Full_Name;
            entity.Enabled = entity1.Enabled;
            entity.Last_Login = entity1.Last_Login;
            entity.Book_Id = entity1.Book_Id;
            BookUserDBContext.SaveChanges();
        }
    }
}
