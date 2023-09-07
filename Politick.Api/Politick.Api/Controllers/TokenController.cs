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
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Politick.Api.Services;

namespace Politick.Api.Controllers;
[Route("Token")]
[ApiController]
public class TokenController : Controller
{
    public AppDbContext _db;
    public UserManager<Player> _userManager;
    public JwtConfiguration _jwtConfiguration;
    public TokenController(AppDbContext db, UserManager<Player> userManager, JwtConfiguration jwtConfiguration)
    {
        _db = db;
        _userManager = userManager;
        _jwtConfiguration = jwtConfiguration;
    }

    private async Task<Player> GetPlayerAsync()
    {
        string email = User.Claims.First(e => e.Type == ClaimTypes.Email).Value;
        return await _db.Players.SingleAsync(p => p.Email == email);
    }

    [HttpPost("GetToken")]
    public async Task<IActionResult> GetTokenAsync([FromBody] PlayerCredentials playerCredentials)
    {
        if (string.IsNullOrEmpty(playerCredentials.Email))
        {
            return BadRequest("Email is required");
        }
        if (string.IsNullOrEmpty(playerCredentials.Password))
        {
            return BadRequest("Password is required");
        }

        var player = _db.Players.FirstOrDefault(u => u.Email == playerCredentials.Email);

        if (player is null) { return Unauthorized("The player account was not found"); }

        if (player.Suspended) 
        { 
            if (player.UnsuspendDay <= DateTime.Now.Day)
            { 
                player.Suspended = false;
                player.UnsuspendDay = 0;
            }
            else return Unauthorized("The player account has been suspended");  
        }

        bool results = await _userManager.CheckPasswordAsync(player, playerCredentials.Password);
        if (results)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, player.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(Claims.Random, (new Random()).NextDouble().ToString()),
                new Claim(Claims.Email, player.Email!),
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
    public async Task<IActionResult> CreatePlayerAsync([FromBody] CreatePlayer createPlayer)
    {
        if (string.IsNullOrEmpty(createPlayer.Email))
        {
            return BadRequest("Email is required");
        }
        if (string.IsNullOrEmpty(createPlayer.Password))
        {
            return BadRequest("Password is required");
        }
        if (string.IsNullOrEmpty(createPlayer.SecurityQuestion))
        {
            return BadRequest("Security question is required");
        }
        if (string.IsNullOrEmpty(createPlayer.SecurityAnswer))
        {
            return BadRequest("Security question answer is required");
        }

        var player = new Player(createPlayer.Email, createPlayer.SecurityQuestion, createPlayer.SecurityAnswer);
        player.SecurityAnswer = _userManager.PasswordHasher.HashPassword(player, createPlayer.SecurityAnswer);
        var result = await _userManager.CreateAsync(player, createPlayer.Password);

        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpPost("GetQuestion")]
    public async Task<IActionResult> GetQuestionAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return BadRequest("Email is required");
        }

        Player? player = await _db.Players.SingleOrDefaultAsync(p => p.Email == email);

        if (player is not null)
        {
            return Ok(player.SecurityQuestion);
        }
        return BadRequest("Player was not found");
    }

    [HttpPost("ValidateAnswer")]
    public async Task<IActionResult> ValidateAnswer([FromBody] string[] emailAndAnswer)
    {
        if (emailAndAnswer.Length < 2)
        {
            return BadRequest("Please fill out all fields");
        }
        if (string.IsNullOrEmpty(emailAndAnswer[0]))
        {
            return BadRequest("Email is required");
        }
        if (string.IsNullOrEmpty(emailAndAnswer[1]))
        {
            return BadRequest("Answer is required");
        }

        Player? player = await _db.Players.SingleOrDefaultAsync(p => p.Email == emailAndAnswer[0]);

        if (player is not null)
        {
            var answerVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(player, player.SecurityAnswer, emailAndAnswer[1]);

            if (answerVerificationResult == PasswordVerificationResult.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Incorrect answer");
            }
        }
        return BadRequest("There was an error with finding the user");

    }

    // args[0] - Email
    // args[1] - Security question answer (for extra validation)
    // args[2] - New password
    [HttpPost("UpdatePassword")]
    public async Task<IActionResult> UpdatePasswordAsync([FromBody] string[] args)
    {
        if (args.Length < 3)
        {
            return BadRequest("Please fill out all fields");
        }
        if (string.IsNullOrEmpty(args[0]))
        {
            return BadRequest("Email is required");
        }
        if (string.IsNullOrEmpty(args[1]))
        {
            return BadRequest("Answer is required");
        }
        if (string.IsNullOrEmpty(args[2]))
        {
            return BadRequest("New password is required");
        }

        Player? player = await _db.Players.SingleOrDefaultAsync(p => p.Email == args[0]);

        if (player is null)
        {
            return NotFound("User not found");
        }

        var answerVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(player, player.SecurityAnswer, args[1]);

        if (answerVerificationResult == PasswordVerificationResult.Success)
        {
            var passwordValidator = new PasswordValidator<Player>();
            var validationResult = await passwordValidator.ValidateAsync(_userManager, player, args[2]);

            if (validationResult.Succeeded)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(player);
                var result = await _userManager.ResetPasswordAsync(player, token, args[2]);

                if (result.Succeeded)
                {
                    return Ok("Password updated successfully");
                }
                else
                {
                    return BadRequest($"{result} - Password reset failed. Please try again.");
                }
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }
        else
        {
            return BadRequest("Answer was not correct");
        }
    }

    [HttpPost("ChangeSecurityQuestion")]
    [Authorize]
    public async Task<IActionResult> UpdateSecurityQuestionAsync([FromBody] SecurityQuestion sc)
    {
        if (string.IsNullOrWhiteSpace(sc.Question))
        {
            return BadRequest("Question is required");
        }
        if (string.IsNullOrWhiteSpace(sc.Answer))
        {
            return BadRequest("Answer is required");
        }

        Player player = await GetPlayerAsync();
        player.SecurityQuestion = sc.Question;
        player.SecurityAnswer = _userManager.PasswordHasher.HashPassword(player, sc.Answer);
        await _db.SaveChangesAsync();
        return Ok();
    }


    [HttpGet("Test")]
    public string Test()
    {
        return "something";
    }

    [HttpGet("TestToken")]
    [Authorize]
    public IActionResult TestToken()
    {
        return Ok(User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Email)?.Value);
    }

    //[HttpGet("testadmin")]
    //[Authorize(Roles = Roles.Admin)]
    //public string TestAdmin()
    //{
    //    return "Authorized as Admin";
    //}

}