using BaseIbge.Application.Dto;

namespace BaseIbge.Application.Interfaces;

public interface ILoginApplication
{
    Task<string> GetToken(LoginRequest loginRequest);
}
