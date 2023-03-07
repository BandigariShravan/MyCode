using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //comment
    public class LibraryController : ControllerBase
    {
        private readonly LibraryAPIDBContext _libraryAPIDBContext;
        public LibraryController(LibraryAPIDBContext libraryAPIDBContext)
        {
            _libraryAPIDBContext = libraryAPIDBContext;
        }
        // GET: api/<LibraryController>
        [HttpGet]
        public IEnumerable<Library> Get()
        {
            return _libraryAPIDBContext.Libraries1 ;
        }

        // GET api/<LibraryController>/5
        [HttpGet("{id}")]
        public Library Get(int id)
        {
            var library= _libraryAPIDBContext.Libraries1.Find(id);
            return library!;
        }

        // POST api/<LibraryController>
        [HttpPost]
        public void Post([FromBody] Library value)
        {
            _libraryAPIDBContext.Libraries1.Add(value);
            _libraryAPIDBContext.SaveChanges();
        }

        // PUT api/<LibraryController>/5
        [HttpPut("{id}")]
        public void Put(int id,Library library)
        {
            var value = _libraryAPIDBContext.Libraries1.Find(id);
            if (value != null)
            {
                value.Author = library.Author;
                _libraryAPIDBContext.SaveChanges();
            }
        }
        //comment
        // DELETE api/<LibraryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteLibrary= _libraryAPIDBContext.Libraries1.Find(id);
            if(deleteLibrary != null)
            {
                _libraryAPIDBContext.Libraries1.Remove(deleteLibrary);
                _libraryAPIDBContext.SaveChanges();
                return Ok("DELeted");
            }
            return Ok(" not DELeted");
        }
    }
}
