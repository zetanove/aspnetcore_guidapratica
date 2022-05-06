using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecureTodoWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SecureTodoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IConfiguration _config;
        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        private JwtSecurityToken GenerateToken(UserLogin user)
        {
            var key = System.Text.Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var secret = new SymmetricSecurityKey(key);

            var jwtToken = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: new List<Claim>()
                {
                    new Claim( ClaimTypes.Name,user.Username),
                    new Claim( ClaimTypes.Role, "administrator"),
                },
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(
                    _config["JWT:ExpirationTimeInMinutes"])),
                signingCredentials: new SigningCredentials(
                    secret, SecurityAlgorithms.HmacSha256)
                );

            return jwtToken;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin model)
        {
            //simula autenticazine
            if(model.Username=="antonio" && model.Password=="password")
            {
                var token = GenerateToken(model);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(jwt);
            }

            return Unauthorized();
        }
    }
}
