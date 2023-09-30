using CountryGWP.API.Models;
using CountryGWP.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CountryGWP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                var result = await _gwpRepository.GetAverageGwpAsync(request.Country, request.Lob);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
