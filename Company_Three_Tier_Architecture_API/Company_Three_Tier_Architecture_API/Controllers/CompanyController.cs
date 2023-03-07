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
    public class CompanyController : ControllerBase
    {
        readonly IDataRepository<Company> _dataRepository;
        public CompanyController(IDataRepository<Company> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public IActionResult Get()
        {
          IEnumerable<Company> companies= _dataRepository.GetAll();
            return Ok(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
           var company= _dataRepository.Get(id);
            return company;
        }

        // POST api/<CompanyController>
        [HttpPost]
        public IActionResult Post([FromBody] Company value)
        {
            _dataRepository.Insert(value);
            return Ok("Comapny Record Added...");
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Company value)
        {
            var Company=_dataRepository.Get(id);
            _dataRepository.Update(Company, value);
            return Ok("Record Updated...");
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Company = _dataRepository.Get(id);
            _dataRepository.Delete(Company);
            return Ok("Record Deleted..");
        }
    }
}
