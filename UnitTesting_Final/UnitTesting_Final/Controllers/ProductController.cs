using Microsoft.AspNetCore.Mvc;
using UnitTesting_Final.DataRepository;
using UnitTesting_Final.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnitTesting_Final.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataRepository dataRepository;
        public ProductController(IDataRepository _dataRepository)
        {
            dataRepository= _dataRepository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return dataRepository.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product= dataRepository.Get(id);
            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            dataRepository.Insert(value);
            return Ok("Product is Added...");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            Product product= dataRepository.Get(id);
            if (product != null)
            {
                return NotFound();
            }
            else
            {
                dataRepository.Update(product, value);
                return Ok("Product Added...");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            dataRepository.Delete(id);
            return Ok("Product deleted...");
        }
    }
}
