using BAL.DataRepository;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assessmemt_API_09_02_2023.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IDataMainRepository<Employee> _dataMainRepository;
        readonly IGetAllRepository<Employee> _getAllRepository;
        public EmployeeController(IDataMainRepository<Employee> dataMainRepository, IGetAllRepository<Employee> getAllRepository)
        {
            _dataMainRepository = dataMainRepository;
            _getAllRepository = getAllRepository;
        }

        // GET: api/<EmployeeController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Employee> data = await _getAllRepository.GetAll();
                if (data == null)
                {
                    return NotFound("No Data Found...");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw new Exception(ex.ToString());
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Id Cannot be Null");
                }
                else
                {
                    var record = await _dataMainRepository.Get(id);
                    if (record == null)
                    {
                        return NotFound("Not Found");
                    }
                    else
                    {
                        return Ok(record);
                    }
                }
            }
            catch (OutOfMemoryException ome)
            {
                return BadRequest(ome.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw new Exception(ex.ToString());
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee value)
        {
            try
            {
                var Employee = await _dataMainRepository.Insert(value);
                if (Employee == null)
                {
                    return NotFound("Entered Employee's companyId is not Exist...");
                }
                if (Employee.EmployeeName == "No Name")
                {
                    return NotFound("Employee should be unique.....");
                }
               return CreatedAtAction(nameof(GetById), new {id=Employee.EmployeeeId},Employee);
            }
            catch (NullReferenceException nre)
            {
                return BadRequest(nre.Message);
            }
            catch (OutOfMemoryException ome)
            {
                return BadRequest(ome.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw new Exception(ex.ToString());
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee value)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Id Cannot be Null");
                }
                else
                {
                    var record = await _dataMainRepository.Get(id);
                    if (record == null)
                    {
                        return NotFound("Id " + id + " Details Not Found to update");
                    }
                    else
                    {
                        await _dataMainRepository.Update(record, value);
                        return Ok("Records Updated...");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw new Exception(ex.ToString());
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Id Cannot be Null");
                }
                else
                {
                    var record = await _dataMainRepository.Get(id);
                    if (record == null)
                    {
                        return NotFound("Id " + id + " Details Not Found to Delete");
                    }
                    else
                    {
                        await _dataMainRepository.Delete(record);
                        return Ok(id + "  Record Deleted...");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw new Exception(ex.ToString());
            }
        }
    }
}