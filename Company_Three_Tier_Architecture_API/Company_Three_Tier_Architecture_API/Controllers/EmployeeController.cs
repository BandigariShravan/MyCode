using BAL.Repository;
using Company_Three_Tier_Architecture_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company_Three_Tier_Architecture_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IDataRepository<Employeee> _datarepository;
        public EmployeeController(IDataRepository<Employeee> datarepository)
        {
            _datarepository = datarepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Employeee> employees= _datarepository.GetAll();
            return Ok(employees);
        }

        private IActionResult ok(IEnumerable<Employeee> employees)
        {
            throw new NotImplementedException();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employeee Get(int id)
        {
            return _datarepository.Get(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] Employeee value)
        {
            _datarepository.Insert(value);
            return Ok("Empoyee Record Added....");

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employeee value)
        {
            var Employee = _datarepository.Get(id);
            _datarepository.Update(Employee,value);
            return Ok("Record Updated....");
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Employee = _datarepository.Get(id);
            _datarepository.Delete(Employee);
            return Ok("Record Deleted....");
        }
    }
}
