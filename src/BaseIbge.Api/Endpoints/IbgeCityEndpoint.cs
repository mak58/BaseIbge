using Asp.Versioning.Builder;
using BaseIbge.Application.Interfaces;
using BaseIbge.Domain.ViewModels;

namespace BaseIbge.Api.Endpoints;

public static class IbgeCityEndpoint
{
   public static void MapIbgeCityEndpoint(this IEndpointRouteBuilder endpoint, ApiVersionSet versionSet) 
   {
      var group = endpoint
                  .MapGroup("place/")
                  .WithTags("Places")
                  .WithApiVersionSet(versionSet)
                  .MapToApiVersion(1)
                  .RequireAuthorization();

      group.MapGet("", (IPlacesApplication placesApplication) =>
      {
         var place = placesApplication.GetAsync();

         return place is not null ? Results.Ok(place.Result) : Results.BadRequest();
      })
      .WithDisplayName("GetAll");             


      group.MapGet("{id}", async (IPlacesApplication placesApplication, int id) => 
      {  
         var place = placesApplication.GetByIdAsync(id).Result;
         return place is not null ? Results.Ok(place) : Results.NotFound();
      })
      .WithDisplayName("GetById");


      endpoint.MapGet("placeByCity", (IPlacesApplication placesApplication,  string city) => 
      {  
         var place = placesApplication.GetByCityAsync(city);                         
         return place is not null ? Results.Ok(place.Result) : Results.NotFound();
      })
      .WithDisplayName("GetByCity")
      .WithTags("Places");


      endpoint.MapGet("placeByState", (IPlacesApplication placesApplication, string state) => 
      {
         var place = placesApplication.GetByStateAsync(state); 
         return place is not null ? Results.Ok(place.Result) : Results.NotFound();
      })
      .WithDisplayName("GetByState")
      .WithTags("Places");


      group.MapPost("", async (IPlacesApplication placesApplication, PlaceRequest placeRequest) => 
      {      
         var place = await placesApplication.AddPlaceAsync(placeRequest);

         return place is not null ? Results.Ok(place) : Results.BadRequest(placeRequest.Notifications);
      })
      .WithDisplayName("PostPlace");

      group.MapPut("{id}", async (IPlacesApplication placesApplication, PlaceRequest placeRequest, int id) => 
      {         
         var place = await placesApplication.UpdatePlaceAsync(placeRequest, id);

         return place is not null ? Results.Ok(placeRequest.Id) : Results.BadRequest();
      })
      .WithDisplayName("PutPlace");

      group.MapDelete("{id}", async (IPlacesApplication placesApplication, int id) =>
      {
         var place = placesApplication.RemovePlace(id);

         return place is true ? Results.Ok(true) : Results.BadRequest();
      })
      .WithDisplayName("DeletePlace");
   }
}
