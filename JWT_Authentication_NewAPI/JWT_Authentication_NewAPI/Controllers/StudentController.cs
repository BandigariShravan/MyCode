using JWT_Authentication_NewAPI.Models;
using JWT_Authentication_NewAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT_Authentication_NewAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDataRepository<Student> _studentRepository;
        public StudentController(IDataRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            var students=_studentRepository.GetAll();
            return Ok(students);
        }

        //GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            var student = _studentRepository.GetAllStudents();
        }

        //// POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student value)
        {
            _studentRepository.AddStudent(value);
            return Ok("Book is Added");
        }

        //// PUT api/<StudentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<StudentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
