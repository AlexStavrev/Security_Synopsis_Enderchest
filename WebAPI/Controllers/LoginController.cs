using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.DTOs;
using WebAPI.DTOs.Converters;
using WebAPI.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUserRepo _userRepo;
    private readonly JWT_Helper _jwtHelper;

    public LoginController(IUserRepo userRepo, IConfiguration configuration)
    {
        _userRepo = userRepo;
        _jwtHelper = new JWT_Helper(configuration);
    }

    // POST api/login

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<UserDto?>> PostAsync([FromBody] UserDto userDto)
    {
        if (userDto.Password == null || userDto.Email == null)
        {
            return BadRequest("Email or Password cannot be null");
        }

        var user = DtoConverter<UserDto, User>.From(userDto);
        Guid? returnedId = await _userRepo.LoginAsync(user);
        if (returnedId.HasValue && returnedId.Value != Guid.Empty)
        {
            userDto.Guid = returnedId.Value;
            string jwtToken = _jwtHelper.GenerateToken(userDto);
            Response.Cookies.Append("X-Access-Token", jwtToken,
                new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddMinutes(_jwtHelper.GetTokenMinutesDuration())
                });

            return Ok(returnedId);
        }
        else
        {
            return NotFound("Invalid email or password");
        }
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult<Guid?>> CreateAsync([FromBody] UserDtoNoGuid userDtoNoGuid)
    {
        if (userDtoNoGuid.Password == null || userDtoNoGuid.Email == null)
        {
            return BadRequest("Email or Password cannot be null");
        }

        var user = DtoConverter<UserDtoNoGuid, User>.From(userDtoNoGuid);
        Guid? returnedGuid = await _userRepo.CreateAsync(user);
        if (returnedGuid.HasValue && returnedGuid != Guid.Empty)
        {
            return Ok(returnedGuid);
        }
        return BadRequest();
    }

    [HttpGet("Salt/{email}")]
    public async Task<ActionResult<byte[]>> GetSaltAsync(string email)
    {
        if (email.IsNullOrEmpty())
        {
            return BadRequest("Email cannot be null");
        }

        byte[]? returnedSalt = await _userRepo.GetSaltAsync(email);
        if (returnedSalt != null && returnedSalt.Length == 16)
        {
            return Ok(returnedSalt);
        }
        return BadRequest();
    }

    [HttpGet("getUserIdByEmail/{email}")]
    public async Task<ActionResult<Guid>> GetUserByEmail(string email)
    {
        if (email.IsNullOrEmpty())
        {
            return BadRequest("Email cannot be null");
        }

        var userId = await _userRepo.GetUserIdByEmail(email);
        if (userId.HasValue)
        {
            return Ok(userId.Value);
        }
        return BadRequest();
    }
}