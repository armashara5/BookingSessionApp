using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using ApplicationLayer.ServicesContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PresentationSecureApi.Models;
using PresentationSecureApi.Services;

namespace PresentationSecureApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly ISessionService _sessionService;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, ISessionService sessionService, IInstructorService instructorService, IStudentService studentService)
        {
            _logger = logger;
            _sessionService = sessionService;
            _studentService = studentService;
        }

        //get student by id
        [HttpGet("{id}")]
        public async Task<StudentVM> Get(string id)
        {
            var result = await _studentService.GetStudentByIdAsync(id);
            var student = ManualMapper.GetStudentVm(result);
            return student;
        }
       
        //create student
        [HttpPost("CreateStudent")]
        public async Task<IActionResult> CreateStudent(StudentVM student)
        {
            StudentAppModel studentAppModel = ManualMapper.GetStudentAppModel(student);
            string studentId = await _studentService.CreateStudentAsync(studentAppModel);
            return Ok(studentId);
        }


        [HttpPost("BookSession")]
        public async Task<IActionResult> BookSession(SessionVM session)
        {
            try
            {
            int hours = session.LengthInMinutes / 60;
            int minutes = session.LengthInMinutes % 60;
            var result = await _sessionService.BookSession(session.InstructorId, session.StudentId, session.StartDate, hours, minutes);
            return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
