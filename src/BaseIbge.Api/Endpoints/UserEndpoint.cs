using BaseIbge.Application.Dto;
using BaseIbge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BaseIbge.Api.Endpoints;

public static class UserEndpoint
{
    public static void MapUserEndpoint(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("user");

        group.MapGet("", async (IUserApplication user) => 
        {
            return await user.GetUsers();
        })
        .WithName("GetUser")
        .WithTags("Users");

        group.MapGet("{id:guid}", async (IUserApplication user, Guid id) => 
        {
            return user.GetUserById(id).Result;
        })
        .WithName("GetUserById")
        .WithTags("Users");

        group.MapPost("", async (UserRequest userRequest, IUserApplication user) => 
        {                  
            var newUser = await user.AddUserAsync(userRequest);
            
            return newUser.Result.Succeeded ? Results.Created($"user/", newUser.User.Id) 
                : Results.BadRequest(newUser.Result.Errors);                        
        })
        .WithName("PostUser")
        .WithTags("Users");

        group.MapDelete("{id}", (IUserApplication user, Guid id) => {
            user.RemoveUserAsync(id);

            return Results.Ok();
        })
        .WithName("DeleteUser")
        .WithTags("Users");
    } 
}
