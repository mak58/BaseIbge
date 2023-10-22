using Asp.Versioning.Builder;
using BaseIbge.Application.Dto;
using BaseIbge.Application.Interfaces;

namespace BaseIbge.Api.Endpoints;

public static class TokenEndpoint
{
    public static void MapTokenEndpoint(this IEndpointRouteBuilder endpoint, ApiVersionSet versionSet)
    {
        endpoint.MapPost("login", async (LoginRequest loginRequest, ILoginApplication login) => 
        {
            var getToken = await login
                                .GetToken(loginRequest);
             
            return  getToken is null 
                    ? Results.BadRequest() 
                    : Results.Ok(new 
                    {
                        token = getToken
                    });
        })
        .WithName("PostToken")
        .WithTags("Login")
        .WithApiVersionSet(versionSet)
        .MapToApiVersion(1)
        .AllowAnonymous();    
    }
}
