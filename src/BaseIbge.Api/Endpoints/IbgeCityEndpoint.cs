using BaseIbge.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BaseIbge.Api.Endpoints;

public static class IbgeCityEndpoint
{
   public static void MapIbgeCityEndpoint(this IEndpointRouteBuilder endpoint) 
   {
      var group = endpoint.MapGroup("/place/");

      group.MapGet("", (AppDbContext context) =>
      {
         return  context.Places.ToList();
      })
      .WithDisplayName("GetAll")      
      .WithTags("Places");

      group.MapGet("{id}", (AppDbContext contex, int id) => 
      {
         return contex.Places.FindAsync(id);
      })
      .WithDisplayName("GetById")
      .WithTags("Places");

      endpoint.MapGet("placeByCity", (AppDbContext context, [FromQuery] string city) => {
         return context.Places.Where(x => x.City == city).ToList();
      })
      .WithDisplayName("GetByCity")
      .WithTags("Places");

      endpoint.MapGet("placeByState", (AppDbContext context, [FromQuery] string state) => {
         return context.Places.Where(x => x.State == state ).ToList();
      })
      .WithDisplayName("GetByState")
      .WithTags("Places");

      endpoint.MapPost("", (AppDbContext context, PlaceRequest place) => {

      });

      // endpoint.MapPut("", () => {

      // });

      // endpoint.MapDelete("", () => {

      // });
     
   }
}
