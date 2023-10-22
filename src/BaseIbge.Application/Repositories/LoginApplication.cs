using System.Text;
using BaseIbge.Application.Dto;
using BaseIbge.Application.Interfaces;
using BaseIbge.Application.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BaseIbge.Application.Repositories;

public class LoginApplication : ILoginApplication
{ 
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

    public LoginApplication(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> GetToken(LoginRequest loginRequest)
    {
        var user = _userManager.FindByEmailAsync(loginRequest.Email).Result;
        if(user is null) 
            return string.Empty;

        if(!_userManager.CheckPasswordAsync(user, loginRequest.Password).Result)
            return string.Empty;

        var key = Encoding.ASCII.GetBytes(_configuration["JwtTokensSettings:SecretKey"]);

        return GenerateToken.CreateToken(user.Email, key);
    }

}
