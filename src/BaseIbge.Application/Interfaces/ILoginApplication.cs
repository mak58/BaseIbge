using BaseIbge.Models.Request;

namespace BaseIbge.Application.Interfaces;

public interface ILoginApplication
{
    Task<string> ValidateUser(LoginRequest loginRequest);
}
