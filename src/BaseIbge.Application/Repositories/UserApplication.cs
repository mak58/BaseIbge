using BaseIbge.Application.Dto;
using BaseIbge.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BaseIbge.Application.Repositories;

public class UserApplication : IUserApplication
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserApplication(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserIdentity> AddUserAsync(UserRequest userRequest)
    {
        var user = new IdentityUser {UserName = userRequest.Email, Email = userRequest.Email };        

        var userAdded = new IdentityUser
        {
            UserName = user.UserName,
            Email = user.Email
        };
        
        var result =  await _userManager.CreateAsync(user, userRequest.Email);                        

        return new UserIdentity
        {
            User = userAdded,
            Result = result
        };
    }

    public async Task<IdentityUser> GetUserById(Guid id)
    {
        var userId = id.ToString();
        var user = _userManager.Users.Where(x => x.Id == userId).FirstOrDefault();

        return user;
    }


    public async Task<List<UserResponse>> GetUsers()
    {
        var users = _userManager.Users.ToList();    

        var response = users
                    .Select(u => 
                    new UserResponse(u.Id, u.Email)).ToList();
        return response; 
    }

    public async Task<bool> RemoveUserAsync(Guid id)
    {
        var userId = id.ToString();
        var user = _userManager.Users.Where(x => x.Id == userId).FirstOrDefault();

        if (user is null) return false;

        await _userManager.DeleteAsync(user);

        return true;
    }
}
