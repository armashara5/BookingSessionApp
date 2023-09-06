using ApplicationLayer.RepositoriesContracts.ApplicationModels;
using ApplicationLayer.ServicesContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PresentationSecureApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PresentationSecureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IInstructorService _instructorService;
        private readonly IStudentService _studentService;
        private readonly ILogger<ConfigController> _logger;


        public AccountController(ILogger<ConfigController> logger, IConfiguration configuration, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IInstructorService instructorService, IStudentService studentService )
        {
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _instructorService = instructorService;
            _studentService = studentService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserModel registerUser)
        //public async Task<IActionResult> Register(string userName, string email, string password, int userType)
        {
            var user = new IdentityUser
            {
                UserName = registerUser.userName,
                Email = registerUser.email,
                PasswordHash = "!@salt for hashing the password$%",
            };
            // Generate email confirmation token

            var result = await _userManager.CreateAsync(user, registerUser.password);
            if (result.Succeeded)
            {
                //// Generate email confirmation token
                //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //// Generate confirmation link
                //var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

                _logger.LogInformation("User registered successfully.");
                if (registerUser.userType == 1)
                {
                    InstructorAppModel instructor = ManualMapper.GetInstructorAppModel(user);
                    await _instructorService.CreateInstructorAsync(instructor);
                    _logger.LogInformation("Instuctor registered successfully.");

                }
                else
                {
                    var student = ManualMapper.GetStudentAppModel(user);
                   await _studentService.CreateStudentAsync(student);
                    _logger.LogInformation("Student registered successfully.");

                }
                await _signInManager.SignInAsync(user, false);

                var token = JwtHelper.GenerateJwtToken(user.Id, user.UserName, _configuration);

                return Ok(new { Token = token, UserId = user.Id });
            }
            return BadRequest(result.Errors);
        }

        //[HttpGet("ConfirmEmail")]
        //public async Task<IActionResult> ConfirmEmail(string userId, string token)
        //{
        //    if (userId == null || token == null)
        //    {
        //        return BadRequest("Invalid email confirmation token.");
        //    }

        //    var user = await _userManager.FindByIdAsync(userId);

        //    if (user == null)
        //    {
        //        return NotFound($"User not found with ID '{userId}'.");
        //    }

        //    var result = await _userManager.ConfirmEmailAsync(user, token);

        //    if (result.Succeeded)
        //    {
        //        return Ok("Email confirmed successfully. You can now log in.");
        //    }
        //    else
        //    {
        //        return BadRequest("Email confirmation failed.");
        //    }
        //}

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserModel loginUser)
        {
            var user = await _userManager.FindByNameAsync(loginUser.userName);

            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, loginUser.password, false, false);
                if (signInResult.Succeeded)
                {
                    _logger.LogInformation("User logged in successfully.");

                    var token = JwtHelper.GenerateJwtToken(user.Id, user.UserName, _configuration);

                    return Ok(new { Token = token, UserId = user.Id });
                }
            }
            return BadRequest("Invalid username or password");
        }

        [Authorize]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        //private string GenerateJwtToken(IdentityUser user)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.UserName??""),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(ClaimTypes.NameIdentifier, user.Id)
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]??""));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

        //    var token = new JwtSecurityToken(
        //        _configuration["Jwt:Issuer"],
        //        _configuration["Jwt:Issuer"],
        //        claims,
        //        expires: expires,
        //        signingCredentials: creds
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
    public class RegisterUserModel
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int userType { get; set; }
    }
    public class LoginUserModel
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
