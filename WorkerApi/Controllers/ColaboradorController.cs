using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkerApi.Models;

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
        public IActionResult DadosColaborador([FromBody] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
