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
    public class DriverLicenseController : ControllerBase
    {
        readonly IMainRepository<DriverLicense> _repository;
        readonly IInsertRepository<DriverLicense> _insertRepository;
        readonly IUpdateRepository<DriverLicense> _updateRepository;
        readonly IDeleteRepository<DriverLicense> _deleteRepository;
        public DriverLicenseController(IMainRepository<DriverLicense> repository,IInsertRepository<DriverLicense> insertRepository, IUpdateRepository<DriverLicense> updateRepository, IDeleteRepository<DriverLicense> deleteRepository)
        {
            _repository = repository;
            _insertRepository = insertRepository;
            _updateRepository = updateRepository;
            _deleteRepository = deleteRepository;
        }

        // GET: api/<DriverLicenseController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<DriverLicense> driverLicenses= _repository.GetAll();
            if (driverLicenses != null)
            {
                return Ok(driverLicenses);
            }
            else
            {
                return BadRequest("Not Found....");

            }
            
        }

        // GET api/<DriverLicenseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var driverLicense = _repository.Get(id);
            if (driverLicense != null)
            {
                return Ok(driverLicense);
            }
            else
            {
                return BadRequest("Not Found....");

            }
            
        }

        // POST api/<DriverLicenseController>
        [HttpPost]
        public IActionResult Post([FromBody] DriverLicense value)
        {
            _insertRepository.Insert(value);

            return Ok("Records Added.....");
        }

        // PUT api/<DriverLicenseController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DriverLicense value)
        {
            var driver= _repository.Get(id);
            _updateRepository.Update(driver, value);
            if (driver != null)
            {
                return Ok("Records Updated .....");
            }
            else
            {
                return BadRequest("Not Found....");

            }
            
        }

        // DELETE api/<DriverLicenseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var driver=_repository.Get(id);
            _deleteRepository.Delete(driver);
            if (driver != null)
            {
                return Ok("Records Deleted....");
            }
            else
            {
                return BadRequest("Not Found....");

            }
            
        }
    }
}
