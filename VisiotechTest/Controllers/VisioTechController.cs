using Microsoft.AspNetCore.Mvc;
using VisiotechTest.Application.Interfaces;

namespace VisiotechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisioTechController : Controller
    {
        private readonly ILogger<VisioTechController> _logger;
        private readonly IVisiontechService _visiontechService;        

        public VisioTechController(ILogger<VisioTechController> logger, 
            IVisiontechService visiontechService)
        {
            _logger = logger;
            _visiontechService = visiontechService;
        }

        [HttpGet("managers/ids")]
        public async Task<IActionResult> GetManagerIDs()
        {
            var result = await _visiontechService.GetManagersIds();
            return Ok(result);
        }

        [HttpGet("managers/taxnumbers")]
        public async Task<IActionResult> GetManagersTaxnumbersOrderByManagerName([FromQuery] bool sorted = true)
        {
            var result = await _visiontechService.GetManagersTaxnumbersOrderByManagerName();
            return Ok(result);
        }

        [HttpPost("grapes/area")]
        public async Task<IActionResult> GetGrapesArea()
        {
            var result = await _visiontechService.GetGrapesArea();
            return Ok(result);
        }

        [HttpPost("/managers/totalarea")]
        public async Task<IActionResult> GetManagersTotalArea()
        {
            var result = await _visiontechService.GetManagerTotalArea();
            return Ok(result);
        }

        [HttpGet("/vineyards/managers")]
        public async Task<IActionResult> GetVineyardsByManeger()
        {
            var result = await _visiontechService.GetVineyardsByManeger();
            return Ok(result);
        }
    }
}
