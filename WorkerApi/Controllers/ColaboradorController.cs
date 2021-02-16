using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkerApi.Models;

namespace WorkerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController : ControllerBase
    {

        private readonly ILogger<ColaboradorController> _logger;

        public ColaboradorController(ILogger<ColaboradorController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
