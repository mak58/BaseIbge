using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BaseIbge.Application.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BaseIbge.Application.Security;

public static class GenerateToken
{
    public static string CreateToken(string user, byte[] key)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, user )
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = "Audience",
            Issuer = "baseIbgeIssuer",
            Expires = DateTime.UtcNow.AddHours(2)                     
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);        
    }
}
