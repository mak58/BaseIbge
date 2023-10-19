using BaseIbge.Application.Dto;
using Microsoft.AspNetCore.Identity;

namespace BaseIbge.Application.Interfaces;

public interface IUserApplication
{
    Task<List<UserResponse>> GetUsers();
    Task<IdentityUser> GetUserById(Guid id);
    Task<UserIdentity> AddUserAsync(UserRequest userRequest);
    Task<bool> RemoveUserAsync(Guid id);
}
