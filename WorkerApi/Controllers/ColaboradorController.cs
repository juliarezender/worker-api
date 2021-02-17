using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Modelos;
using Application.Service;

namespace WorkerApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/colaborador/adicionar")]
    public class ColaboradorController : ControllerBase
    {

        private readonly ILogger<ColaboradorController> _logger;
        private IAzureQueue _azureQueue;

        public ColaboradorController(ILogger<ColaboradorController> logger, IAzureQueue azureQueue)
        {
            _logger = logger;
            _azureQueue = azureQueue;
        }

        [HttpPost]
        public IActionResult DadosColaboradorAsync([FromBody] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _azureQueue.ReceberDados(colaborador);
                return Ok("Armazenado na queue");
            }
            return BadRequest(ModelState);
        }
    }
}
