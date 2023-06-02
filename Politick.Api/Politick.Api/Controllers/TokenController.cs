using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Politick.Api.Data;
using Politick.Api.Identity;
using Politick.Api.Models;

namespace Wordle.Api.Controllers;
[Route("Token")]
[ApiController]
public class TokenController : Controller
{
    public AppDbContext _context;
    public UserManager<Player> _userManager;
    public JwtConfiguration _jwtConfiguration;
    public TokenController(AppDbContext context, UserManager<Player> userManager, JwtConfiguration jwtConfiguration)
    {
        _context = context;
        _userManager = userManager;
        _jwtConfiguration = jwtConfiguration;
    }

    [HttpPost("GetToken")]
    public async Task<IActionResult> GetToken([FromBody] PlayerCredentials playerCredentials)
    {
        if (string.IsNullOrEmpty(playerCredentials.Email))
        {
            return BadRequest("Email is required");
        }
        if (string.IsNullOrEmpty(playerCredentials.Password))
        {
            return BadRequest("Password is required");
        }

        var player = _context.Players.FirstOrDefault(u => u.Email == playerCredentials.Email);

        if (player is null) { return Unauthorized("The user account was not found"); }

        bool results = await _userManager.CheckPasswordAsync(player, playerCredentials.Password);
        if (results)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, player.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(Claims.UserId, player.Id.ToString()),
                new Claim(Claims.Random, (new Random()).NextDouble().ToString()),
                new Claim(Claims.Email, player.Email!.ToString().Substring(0,player.Email.ToString().IndexOf("@"))),
            };
            var roles = await _userManager.GetRolesAsync(player);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _jwtConfiguration.Issuer,
                audience: _jwtConfiguration.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtConfiguration.ExpirationInMinutes),
                signingCredentials: credentials
            );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = jwtToken });
        }
        return Unauthorized("The email or password is incorrect");
    }

    [HttpPost("CreatePlayer")]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayer createPlayer)
    {
        if (string.IsNullOrEmpty(createPlayer.Email))
        {
            return BadRequest("Email is required");
        }
        if (string.IsNullOrEmpty(createPlayer.Password))
        {
            return BadRequest("Password is required");
        }
        var user = new Player(createPlayer.Email);
        var result = await _userManager.CreateAsync(user, createPlayer.Password);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpGet("test")]
    [Authorize]
    public string Test()
    {
        return "something";
    }

    //[HttpGet("testadmin")]
    //[Authorize(Roles = Roles.Admin)]
    //public string TestAdmin()
    //{
    //    return "Authorized as Admin";
    //}

}