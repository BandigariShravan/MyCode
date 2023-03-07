using LibraryAPIUsingLinq.Data;
using LibraryAPIUsingLinq.Models;
using LibraryAPIUsingLinq.Repository;
using System.Data.SqlTypes;

namespace LibraryAPIUsingLinq.DataManager
{
    //using IDataRepository
    public class LibraryManager : IDataRepository<Library>
    {
        readonly LibraryAPIDBContext _libraryAPIDBContext;
        public LibraryManager(LibraryAPIDBContext libraryAPIDB)
        {
            _libraryAPIDBContext= libraryAPIDB;
        }
        public IEnumerable<Library> GetAll() 
        {
            return _libraryAPIDBContext.LibrariesUsingLinq.ToList();
        }
        public Library Get(int id) => _libraryAPIDBContext.LibrariesUsingLinq.FirstOrDefault(l => l.id == id);
        public void Add(Library entity)
        {
            _libraryAPIDBContext.LibrariesUsingLinq.Add(entity);
            _libraryAPIDBContext.SaveChanges();
        }
        public void Delete(Library entity)
        {
            _libraryAPIDBContext.LibrariesUsingLinq?.Remove(entity);
            _libraryAPIDBContext.SaveChanges();
        }
        public void Update(Library dbEntity, Library entity)
        {
            dbEntity.Title= entity.Title;
            dbEntity.Author= entity.Author;
            dbEntity.Publisher= entity.Publisher;
            dbEntity.Publication_Year= entity.Publication_Year;
            dbEntity.Genre= entity.Genre;
            dbEntity.ISBN= entity.ISBN;
            dbEntity.Number_Of_Pages= entity.Number_Of_Pages;

            _libraryAPIDBContext.SaveChanges();
        }

       
    }
}