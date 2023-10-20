using BaseIbge.Application.Dto;
using BaseIbge.Application.Interfaces;

namespace BaseIbge.Api.Endpoints;

public static class TokenEndpoint
{
    public static void MapTokenEndpoint(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("login", async (LoginRequest loginRequest, ILoginApplication login) => 
        {
            var getToken = await login.GetToken(loginRequest);
            return Results.Ok(new 
            {
               token = getToken
            });
        })
        .WithName("PostToken")
        .WithTags("Login");
    }
}
