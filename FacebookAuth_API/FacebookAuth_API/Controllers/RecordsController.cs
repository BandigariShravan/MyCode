
using BAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoogleAuth_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IDataRepository<Record> _dataRepository;
        public RecordsController(IDataRepository<Record> data)
        {
            _dataRepository= data;
        }
        // GET: api/<RecordsController>
        
        [HttpGet("Get")]
        public IActionResult Get()
        {
           IEnumerable<Record> records = _dataRepository.GetAll();
            return Ok(records);
        }

        // GET api/<RecordsController>/5
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var record = _dataRepository.Get(id);
            return Ok(record);
        }

        // POST api/<RecordsController>
        [HttpPost("Post")]
        public IActionResult Post([FromBody] Record value)
        {
           Record record= _dataRepository.Add(value);
            return Ok(record);
        }

        // PUT api/<RecordsController>/5
        [HttpPut("Put/{id}")]
        public IActionResult Put(int id, [FromBody] Record value)
        {
            var record= _dataRepository.Get(id);
            _dataRepository.Update(record,value);
            return Ok("Updated");

        }

        // DELETE api/<RecordsController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var record = _dataRepository.Get(id);
            _dataRepository.Delete(record);
            return Ok("Deleted");
        }
    }
}
