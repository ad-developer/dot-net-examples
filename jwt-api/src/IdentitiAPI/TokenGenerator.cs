using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace IdentitiAPI;

public class TokenGenerator
{
    public string GenerateToken(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = "ThisIsATestTokenThisIsATestTokenThisIsATestTokenThisIsATestToken"u8.ToArray();
        var claims = new List<Claim>{
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.Sub, email)
        };

        var tokenDescriptot = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(15),
            Issuer = "https://id.domain.com",
            Audience = "https://domain.com",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptot);
        return tokenHandler.WriteToken(token);
    }
}