using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        // Здесь должна быть логика проверки учетных данных пользователя
        // Это просто пример без реальной проверки
        if (loginModel.Username == "user" && loginModel.Password == "pass")
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, loginModel.Username)
                // Можно добавить другие утверждения (claims) здесь
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ВашСекретныйКлюч"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        return Unauthorized();
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
