using BaseIbge.Application.Interfaces;
using BaseIbge.Domain.ViewModels;
using BaseIbge.Infrastructure.Data;

namespace BaseIbge.Api.Endpoints;

public static class IbgeCityEndpoint
{
   public static void MapIbgeCityEndpoint(this IEndpointRouteBuilder endpoint) 
   {
      var group = endpoint.MapGroup("/place/");

      group.MapGet("", (AppDbContext context) =>
      {
         var place = context.Places.ToList();

         return Results.Ok(place);
      })
      .WithDisplayName("GetAll")      
      .WithTags("Places");


      group.MapGet("{id}", async (IPlacesApplication placesApplication, int id) => 
      {
         return  placesApplication.GetById(id);
      })
      .WithDisplayName("GetById")
      .WithTags("Places");


      endpoint.MapGet("placeByCity", (IPlacesApplication placesApplication,  string city) => 
      {                  
         return placesApplication.GetByCityAsync(city);         
      })
      .WithDisplayName("GetByCity")
      .WithTags("Places");


      endpoint.MapGet("placeByState", (IPlacesApplication placesApplication, string state) => 
      {
         return placesApplication.GetByState(state);
      })
      .WithDisplayName("GetByState")
      .WithTags("Places");


      group.MapPost("", async (IPlacesApplication placesApplication, PlaceRequest placeRequest) => 
      {
         var place = placeRequest.MapTo();
         if (!placeRequest.IsValid) return Results.BadRequest(placeRequest.Notifications);

         await placesApplication.AddPlace(place);

         return Results.Ok(place);         
      })
      .WithDisplayName("PostPlace")
      .WithTags("Places");

      group.MapPut("{id}", async (IPlacesApplication placesApplication, PlaceRequest placeRequest, int id) => 
      {         
         var request = placeRequest.MapTo();

            if (!placeRequest.IsValid) 
               return Results.BadRequest(placeRequest.Notifications);

         await placesApplication.UpdatePlace(placeRequest, id);

         return Results.Ok(placeRequest);
      })
      .WithDisplayName("PutPlace")
      .WithTags("Places");

      group.MapDelete("{id}", async (IPlacesApplication placesApplication, int id) =>
      {
         var place = placesApplication.RemovePlace(id);

         return Results.Ok(true);
      })
      .WithDisplayName("DeletePlace")
      .WithTags("Places");     
   }
}
