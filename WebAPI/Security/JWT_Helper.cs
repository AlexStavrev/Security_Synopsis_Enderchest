using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.DTOs;

namespace WebAPI.Security;

internal class JWT_Helper
{
    private readonly IConfiguration _configuration;
    public JWT_Helper(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("JwtSettings");
    }

    public string GenerateToken(UserDto user)
    {
        var claims = new List<Claim>
        {
            new Claim("user_guid", user.Guid.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Issuer"],
            audience: _configuration["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["DurationMinutes"])),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]!)),
                SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // can be used to validate X-Access-Token
    public bool ValidateToken(string? token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return false;
        }
        var mySecret = Encoding.UTF8.GetBytes(_configuration["SecretKey"]!);
        var mySecurityKey = new SymmetricSecurityKey(mySecret);
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _configuration["Issuer"]!.ToString(),
                ValidAudience = _configuration["Audience"]!.ToString(),
                IssuerSigningKey = mySecurityKey,
            }, out SecurityToken validatedToken);
            var temp = (JwtSecurityToken)validatedToken;
        }
        catch (SecurityTokenException) // TODO: Figure out if SecurityTokenValidationException is better to catch here
        {
            return false;
        }
        return true;
    }

    public double GetTokenMinutesDuration()
    {
        return Convert.ToDouble(_configuration["DurationMinutes"]);
    }
}
