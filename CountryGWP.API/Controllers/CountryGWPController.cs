using CountryGWP.API.Models;
using CountryGWP.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CountryGWP.API.Controllers
{
    [ApiController]
    [Route("server")]
    public class CountryGwpController : ControllerBase
    {
        private readonly IGWPRepository _gwpRepository;

        public CountryGwpController(IGWPRepository gwpService)
        {
            _gwpRepository = gwpService;
        }

        [HttpPost("api/gwp/avg")]
        public async Task<IActionResult> GetAverageGwp([FromBody] GWPRequest request)
        {
            try
            {
                var result = await _gwpRepository.CalculateAverageGwpAsync(request.Country, request.Lobs.Distinct().ToList());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
