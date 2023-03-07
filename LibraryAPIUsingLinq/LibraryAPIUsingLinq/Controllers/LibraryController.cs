using LibraryAPIUsingLinq.Data;
using LibraryAPIUsingLinq.Models;
using LibraryAPIUsingLinq.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        //private readonly LibraryAPIDBContext _libraryAPIDBContext;
        //public LibraryController(LibraryAPIDBContext libraryAPIDBContext)
        //{
        //    _libraryAPIDBContext = libraryAPIDBContext;
        //}

        private readonly IDataRepository<Library> _libraryRepositoryReadOnly;
        private IDataRepository<Library> _libraryRepository;
        public LibraryController(IDataRepository<Library> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        // GET: api/<LibraryController>
        [HttpGet]
        //public IEnumerable<Library> Get()
        //{
        //    return _libraryAPIDBContext.LibrariesUsingLinq;
        //}
        public IActionResult Get()
        {
            IEnumerable<Library> libraries = _libraryRepository.GetAll();
            return Ok(libraries);
        }

        // GET api/<LibraryController>/5
        [HttpGet("{id}",Name ="Get")]
        //public Library Get(int id)
        //{
        //    var library= _libraryAPIDBContext.LibrariesUsingLinq.Find(id);
        //    return library;
        //}
        public IActionResult Get(int id)
        {
            Library library = _libraryRepository.Get(id);
            if(library == null)
            {
                return NotFound("The Libraray record couldn't be found.");
            }
            return Ok(library);
        }

        // POST api/<LibraryController>
        [HttpPost]
        //public void Post([FromBody] Library value)
        //{
        //    _libraryAPIDBContext.LibrariesUsingLinq.Add(value);
        //    _libraryAPIDBContext.SaveChanges();
        //}
        public IActionResult Post(Library library)
        {
            if(library == null)
            {
                return BadRequest("Library is Null");
            }
            _libraryRepository.Add(library);
            return CreatedAtRoute(
                "Get",
                new { Id = library.id },
                library);
        }
       

        // PUT api/<LibraryController>/5
        [HttpPut("{id}")]
        //public void Put(int id,Library library)
        //{
        //    var value = _libraryAPIDBContext.LibrariesUsingLinq.Find(id);
        //    if (value != null)
        //    {
        //        value.Author = library.Author;
        //        _libraryAPIDBContext.SaveChanges();
        //    }
        //}

        public IActionResult Put(int id, [FromBody] Library library)
        {
            if (library == null)
            {
                return BadRequest("Library is Null");
            }

            Library libraryUpdate = _libraryRepository.Get(id);
            if (libraryUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _libraryRepository.Update(libraryUpdate, library);
            return NoContent();
        }

        // DELETE api/<LibraryController>/5
        [HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var deleteLibrary= _libraryAPIDBContext.LibrariesUsingLinq.Find(id);
        //    if(deleteLibrary != null)
        //    {
        //        _libraryAPIDBContext.LibrariesUsingLinq.Remove(deleteLibrary);
        //        _libraryAPIDBContext.SaveChanges();
        //        return Ok("DELeted");
        //    }
        //    return Ok(" not DELeted");
        //}

        public IActionResult Delete(int id)
        {
            Library removeLibrary = _libraryRepository.Get(id);
            if(removeLibrary==null)
            {
                return NotFound("The Library record couldn't be found.");
            }
            _libraryRepository.Delete(removeLibrary);
            return NoContent();
        }
    }
}
