using ApplicationLayer.ServicesContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationSecureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly ILogger<ConfigController> _logger;
        private readonly IConfigService _configService;

        public ConfigController(ILogger<ConfigController> logger, IConfigService configService)
        {
            _logger = logger;
            _configService = configService;
        }

        [HttpPost("ApplyMigrations")]
        public async Task<IActionResult> ApplyMigrations()
        {
            try
            {
                await _configService.ApplyMigrations();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ResetDb")]
        public async Task<IActionResult> ResetDb()
        {
            try
            {
                await _configService.ResetDb();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
