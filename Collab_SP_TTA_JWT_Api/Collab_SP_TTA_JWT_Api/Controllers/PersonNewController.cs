using BAL.Repository;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collab_SP_TTA_JWT_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonNewController : ControllerBase
    {
        readonly IMainRepositoryNew<Person> _repositoryNew;
        public PersonNewController(IMainRepositoryNew<Person> mainRepository)
        {
            _repositoryNew = mainRepository;
        }
        [HttpGet("Include All")]
        public IActionResult Get()
        {
            IEnumerable<Person> persons = _repositoryNew.GetAll();
            if (persons != null)
            {
                return Ok(persons);
            }
            else
            {
                return BadRequest("Not Found....");
            }
        }

        [HttpGet("Include All by Id")]
        public IActionResult Get(int id)
        {
            var person = _repositoryNew.Get(id);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return BadRequest("Not Found....");
            }
        }
    }
}
