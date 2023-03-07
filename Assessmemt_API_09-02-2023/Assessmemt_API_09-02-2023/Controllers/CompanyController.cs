using BAL.DataRepository;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assessmemt_API_09_02_2023.Controllers
{
    //comment
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly IDataMainRepository<Company> _dataMainRepository;
        readonly IGetAllRepository<Company> _getRepository;
        public CompanyController(IDataMainRepository<Company> dataMainRepository, IGetAllRepository<Company> getRepository)
        {
            _dataMainRepository = dataMainRepository;
            _getRepository = getRepository;
        }

        // GET: api/<CompanyController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Company> data = await _getRepository.GetAll();
                if (data == null)
                {
                    return NotFound("No Data Found...");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               // throw new Exception(ex.ToString());
            }
        }
        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Company value)
        {
            try
            {
                var Company = await _dataMainRepository.Insert(value);
                if (Company == null)
                {
                    return Ok("Company name should be Unique...");
                }
                return CreatedAtAction(nameof(GetById),new {id=Company.CompanyId},Company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //throw new Exception(ex.ToString());
            }
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Company value)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound("Id Cannot be Null Enter Valid Id ");
                }
                else
                {
                    var company = await _dataMainRepository.Get(id);
                    if (company == null)
                    {
                        return NotFound(id + "Not Found....");
                    }
                    else
                    {
                        await _dataMainRepository.Update(company, value);
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

        // DELETE api/<CompanyController>/5
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
                    var company = await _dataMainRepository.Get(id);
                    if (company == null)
                    {
                        return NotFound("Id Details of " + id + " are Not Found");
                    }
                    else
                    {
                        await _dataMainRepository.Delete(company);
                        return Ok(" Records of Id " + id + " are Deleted...");
                    } 
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
                //throw new Exception(ex.ToString());
            }
        }
        [HttpDelete]//("{Delete Many Ids}")]
        public async Task<IActionResult> DeleteMany(List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var company = await _dataMainRepository.Get(id);
                    if (company != null)
                    {
                        await _dataMainRepository.Delete(company);
                    }
                }
                foreach (int id in ids)
                {
                    var Deleted = await _dataMainRepository.Get(id);
                    //return Ok(Deleted+"Deleted sucessfully");
                }
                //return Ok(ids.ToArray());//+"Deleted Successfuly");
                return Ok(ids);//+"Deleted Successfuly");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
               // throw new Exception(ex.ToString());
            }
        }

        // GET api/<CompanyController>/5
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
                    var company = await _dataMainRepository.Get(id);
                    if (company == null)
                    {
                        return NotFound(id + "Not Found");
                    }
                    else
                    {
                        return Ok(company);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
                //throw new Exception(ex.ToString());
            }
        }
    }
}