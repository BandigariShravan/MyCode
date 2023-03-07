using Microsoft.AspNetCore.Mvc;
using OneToMany_BookUser_API.Data;
using OneToMany_BookUser_API.Models;
using OneToMany_BookUser_API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToMany_BookUser_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDataRepository<Book> repository;
        public BookController(IDataRepository<Book> dataRepository)
        {
            repository = dataRepository;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return repository.GetAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            var Record=repository.Get(id);
            return Record;
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            repository.Insert(value);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            var Record = repository.Get(id);
            repository.Update(Record, value);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Record = repository.Get(id);
            repository.Delete(Record);  
        }
    }
}
