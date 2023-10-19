using BaseIbge.Application.Interfaces;
using BaseIbge.Domain.Interfaces;
using BaseIbge.Domain.ViewModels;
using BaseIbge.Infrastructure.Data;
using BasePlace.Domain.Models;

namespace BaseIbge.Api.Endpoints;

public static class IbgeCityEndpoint
{
   public static void MapIbgeCityEndpoint(this IEndpointRouteBuilder endpoint) 
   {
      var group = endpoint.MapGroup("/place/");

      group.MapGet("", (IPlacesApplication placesApplication) =>
      {
         var place = placesApplication.GetAsync();

         return Results.Ok(place.Result);
      })
      .WithDisplayName("GetAll")      
      .WithTags("Places");


      group.MapGet("{id}", async (IPlacesApplication placesApplication, int id) => 
      {
         return  placesApplication.GetByIdAsync(id).Result;
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
         return placesApplication.GetByStateAsync(state);
      })
      .WithDisplayName("GetByState")
      .WithTags("Places");


      group.MapPost("",  (IPlacesApplication placesApplication, PlaceRequest placeRequest) => 
      {      
         var place = placesApplication.AddPlaceAsync(placeRequest);

         return place is not null ? Results.Ok(place.Result) : Results.BadRequest(placeRequest.Notifications);
      })
      .WithDisplayName("PostPlace")
      .WithTags("Places");

      group.MapPut("{id}", async (IPlacesApplication placesApplication, PlaceRequest placeRequest, int id) => 
      {         
         var place = await placesApplication.UpdatePlaceAsync(placeRequest, id);

         return Results.Ok(placeRequest.Id);
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
