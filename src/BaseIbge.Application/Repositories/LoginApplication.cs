using System.Text;
using BaseIbge.Application.Interfaces;
using BaseIbge.Application.Security;
using BaseIbge.Application.Shared;
using BaseIbge.Domain.Interface;
using BaseIbge.Models.Request;

namespace BaseIbge.Application.Repositories;

public class LoginApplication : ILoginApplication
{
    private readonly IUserRepository _userRepository;

    public LoginApplication(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<string> ValidateUser(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserCredentials(loginRequest);
        
        if(!user) return string.Empty;

        return GetToken(loginRequest.Email);
    }

    public static string GetToken(string email)
    {
        var key = Encoding.ASCII.GetBytes(AppConfig.GetConfiguration("JwtTokensSettings:SecretKey"));

        return GenerateToken.CreateToken(email, key);
    }

}
