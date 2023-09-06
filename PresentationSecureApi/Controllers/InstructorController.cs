using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using ApplicationLayer.ServicesContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationSecureApi.Models;
using PresentationSecureApi.Services;

namespace PresentationSecureApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {

        private readonly ILogger<InstructorController> _logger;
        private readonly IInstructorService _instructorService;

        public InstructorController(ILogger<InstructorController> logger, IInstructorService instructorService)
        {
            _logger = logger;
            _instructorService = instructorService;
        }

        [HttpGet("GetInstuctors")]
        public async Task<IActionResult> GetInstuctors()
        {
            try
            {
            IEnumerable<InstructorAppModel> instructorsAppModel = await _instructorService.GetInstuctorsAsync();
            IEnumerable<InstructorVM> instructors = ManualMapper.GetInstuctorsVM(instructorsAppModel);

            return Ok(instructors);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
