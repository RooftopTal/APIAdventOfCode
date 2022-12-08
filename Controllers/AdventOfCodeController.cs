using APIAdventOfCode.Models;
using APIAdventOfCode.Puzzles;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APIAdventOfCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdventOfCodeController : ControllerBase
    {
        private readonly ILogger<AdventOfCodeController> _logger;
        private readonly IAdventofCodeService _aocService;

        public AdventOfCodeController(
            ILogger<AdventOfCodeController> logger,
            IAdventofCodeService aocService)
        {
            _logger = logger;
            _aocService = aocService;
        }

        [HttpGet]
        [Route("Answer/{yearID:int}/{dayID:int}")]
        [EnableCors("BasicPolicy")]
        public AOCResponse AOC(int yearID, int dayID)
        {
            return _aocService.GetAOCAnswer(yearID, dayID);
        }
    }
}
