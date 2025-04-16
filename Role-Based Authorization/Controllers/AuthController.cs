using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Role_Based_Authorization.Data;
using Role_Based_Authorization.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Role_Based_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ApplicationDbContext context, ILogger<AuthController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var dbUser = _context.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (dbUser == null) return Unauthorized("Invalid credentials");

            var claims = new[]
            {
             new Claim(ClaimTypes.Name, dbUser.Username),
             new Claim(ClaimTypes.Role, dbUser.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gfhgfhgfvckvfGHfadaltelinvbgyyjrtzcf"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult GetAdminData()
        {
            return Ok("Hello Admin!");
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("user")]
        public IActionResult GetUserData()
        {
            return Ok("Hello User!");
        }
    }
}
