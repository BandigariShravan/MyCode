using BAL.Repository;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Collab_SP_TTA_JWT_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        readonly IMainRepository<Person> _repository;
        readonly IMainRepositoryNew<Person> _repositoryNew;
        readonly IInsertRepository<Person> _insertRepository;
        readonly IUpdateRepository<Person> _updateRepository;
        readonly IDeleteRepository<Person> _deleteRepository;
        public PersonsController(IMainRepository<Person> repository, IMainRepositoryNew<Person> repositoryNew, IInsertRepository<Person> insertRepository, IUpdateRepository<Person> updateRepository, IDeleteRepository<Person> deleteRepository)
        {
            _repository = repository;
            _repositoryNew = repositoryNew;
            _insertRepository = insertRepository;
            _updateRepository = updateRepository;
            _deleteRepository = deleteRepository;
        }

        // GET: api/<PersonsController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Person> persons = _repository.GetAll();
            if (persons != null)
            {
                return Ok(persons);
            }
            else
            {
                return BadRequest("Not Found....");
            }
        }

        // GET api/<PersonsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var person = _repository.Get(id);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {

                return BadRequest("Not Found....");
            }
        }

        // POST api/<PersonsController>
        [HttpPost]
        public IActionResult Post([FromBody] Person value)
        {
            _insertRepository.Insert(value);
            return Ok("Person Records Added.....");
        }

        // PUT api/<PersonsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person value)
        {
            var person = _repository.Get(id);
            _updateRepository.Update(person, value);
            if (person != null)
            {
                return Ok("Records Updated...");
            }
            else
            {
                return BadRequest("Not Found....");
            }
        }

        // DELETE api/<PersonsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete_Person = _repository.Get(id);
            _deleteRepository.Delete(delete_Person);
            if (delete_Person != null)
            {
                return Ok("Records Deleted...");
            }
            else
            {
                return BadRequest("Not Found....");
            }
        }

        //[HttpGet("Include All")]
        //public IActionResult GetAllInclude()
        //{
        //    IEnumerable<Person> persons = _repositoryNew.GetAllInclude();
        //    if (persons != null)
        //    {
        //        return Ok(persons);
        //    }
        //    else
        //    {
        //        return BadRequest("Not Found....");
        //    }
        //}

        //[HttpGet("Include All by Id")]
        //public IActionResult GetInclude(int id)
        //{
        //    var person = _repositoryNew.GetInclude(id);
        //    if (person != null)
        //    {
        //        return Ok(person);
        //    }
        //    else
        //    {
        //        return BadRequest("Not Found....");
        //    }
        //}
    }
}
