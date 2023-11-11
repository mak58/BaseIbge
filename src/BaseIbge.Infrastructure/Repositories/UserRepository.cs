using BaseIbge.Domain.Interface;
using BaseIbge.Models.Request;
using Microsoft.AspNetCore.Identity;

namespace BaseIbge.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    public UserRepository(UserManager<IdentityUser> userManager)
        => _userManager = userManager;


    public Task<bool> GetUserCredentials(LoginRequest loginRequest)
    {
        var user = _userManager.FindByEmailAsync(loginRequest.Email).Result;
        if(user is null) return Task.FromResult(false);

        return _userManager.CheckPasswordAsync(user, loginRequest.Password);                     
    }

}
