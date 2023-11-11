using BaseIbge.Models.Request;

namespace BaseIbge.Domain.Interface;

public interface IUserRepository
{
    Task<bool> GetUserCredentials(LoginRequest loginRequest);
}
