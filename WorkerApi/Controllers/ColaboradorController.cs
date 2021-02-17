using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Modelos;
using Azure.Storage.Queues;
using System;
using System.Threading.Tasks;

namespace WorkerApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/colaborador/adicionar")]
    public class ColaboradorController : ControllerBase
    {

        private readonly ILogger<ColaboradorController> _logger;

        public ColaboradorController(ILogger<ColaboradorController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> DadosColaboradorAsync([FromBody] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
                QueueClient queue = new QueueClient(connectionString, "to-email"); 
                
                string value = string.Concat(colaborador.Nome, ", ", colaborador.Telefone, ", ", colaborador.Email);
                await InsertMessageAsync(queue, value);
                Console.WriteLine($"Sent: {value}");

                return Ok();
            }
            return BadRequest(ModelState);
        }
        static async Task InsertMessageAsync(QueueClient theQueue, string newMessage)
        {
            if (null != await theQueue.CreateIfNotExistsAsync())
            {
                Console.WriteLine("The queue was created.");
            }

            await theQueue.SendMessageAsync(newMessage);
        }
    }
}
