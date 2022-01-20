using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MissionControl.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MissionControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IConfiguration _configuration;
      
        public LoginController(UserDbContext userDbContext,IConfiguration configuration)
        {
            _context = userDbContext;
            _configuration = configuration;

        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetails = _context.userModels.AsQueryable();
            return Ok(userdetails);
        }
      
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.userModels.Add(userObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Sign up Successfully"

                });
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.userModels.Where(a => a.EmailId == userObj.EmailId && a.UserName == userObj.UserName).FirstOrDefault();


                if (user != null)
                {
                    var token = GenerateToken(user.UserName);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logged In Successfully",
                        Id = user.Id,
                        EmailId = user.EmailId,
                        UserName = user.UserName,
                        JwtToken = token

                    }) ;
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
            }
        }
     
        private string GenerateToken(string UserName)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,UserName),
                new Claim("CompanyName","Preeti Patel")
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);
            return tokenhandler.WriteToken(token);
        }
    }
}
