using Microsoft.AspNetCore.Mvc;
using OneToMany_BookUser_API.Models;
using OneToMany_BookUser_API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OneToMany_UserUser_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> repository;
        public UserController(IDataRepository<User> dataRepository)
        {
            repository = dataRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return repository.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var Record = repository.Get(id);
            return Record;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            repository.Insert(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var Record = repository.Get(id);
            repository.Update(Record, value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Record = repository.Get(id);
            repository.Delete(Record);
        }
    }
}
