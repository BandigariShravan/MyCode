//using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _29_12_2022_Key_Vault_Session.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //    ServiceBusClient client;
        //    ServiceBusSender sender;
        //    const int numofMessages = 3;
        //    var clientOptions = new ServiceBusClientOptions
        //    {
        //        TransportType = ServiceBusTransportType.AmqpWebSockets
        //    };
        //    client = new ServiceBusClient(_configuration["ServiceBusconnString"]);
        //    sender = client.CreateSender("queue");
        //    BinaryData data = null;
        //    ServiceBusMessage message = new ServiceBusMessage("This is sravan Message");
        //    //{
        //    //    Body = null
        //    //};
        //    sender.SendMessageAsync(message).GetAwaiter();
        //}
    }
}
