using Asp.Versioning.Builder;
using BaseIbge.Application.Interfaces;
using BaseIbge.Domain.ViewModels;

namespace BaseIbge.Api.Endpoints;

public static class IbgeCityEndpoint
{
   public static void MapIbgeCityEndpoint(this IEndpointRouteBuilder endpoint, ApiVersionSet versionSet) 
   {
      var group = endpoint.MapGroup("place/");

      group.MapGet("", (IPlacesApplication placesApplication) =>
      {
         var place = placesApplication.GetAsync();

         return place is not null ? Results.Ok(place.Result) : Results.BadRequest();
      })
      .WithDisplayName("GetAll")      
      .WithTags("Places")
      .WithApiVersionSet(versionSet)
      .MapToApiVersion(1)
      .RequireAuthorization();      


      group.MapGet("{id}", async (IPlacesApplication placesApplication, int id) => 
      {  
         var place = placesApplication.GetByIdAsync(id).Result;
         return place is not null ? Results.Ok(place) : Results.NotFound();
      })
      .WithDisplayName("GetById")
      .WithTags("Places")
      .WithApiVersionSet(versionSet)
      .MapToApiVersion(1)
      .RequireAuthorization();


      endpoint.MapGet("placeByCity", (IPlacesApplication placesApplication,  string city) => 
      {  
         var place = placesApplication.GetByCityAsync(city);                         
         return place is not null ? Results.Ok(place.Result) : Results.NotFound();
      })
      .WithDisplayName("GetByCity")
      .WithTags("Places")
      .WithApiVersionSet(versionSet)
      .MapToApiVersion(1)
      .RequireAuthorization();


      endpoint.MapGet("placeByState", (IPlacesApplication placesApplication, string state) => 
      {
         var place = placesApplication.GetByStateAsync(state); 
         return place is not null ? Results.Ok(place.Result) : Results.NotFound();
      })
      .WithDisplayName("GetByState")
      .WithTags("Places")
      .WithApiVersionSet(versionSet)
      .MapToApiVersion(1)
      .RequireAuthorization();;


      group.MapPost("", (IPlacesApplication placesApplication, PlaceRequest placeRequest) => 
      {      
         var place = placesApplication.AddPlaceAsync(placeRequest);

         return place is not null ? Results.Ok(place.Result) : Results.BadRequest(placeRequest.Notifications);
      })
      .WithDisplayName("PostPlace")
      .WithTags("Places")
      .WithApiVersionSet(versionSet)
      .MapToApiVersion(1)
      .RequireAuthorization();;

      group.MapPut("{id}", async (IPlacesApplication placesApplication, PlaceRequest placeRequest, int id) => 
      {         
         var place = await placesApplication.UpdatePlaceAsync(placeRequest, id);

         return place is not null ? Results.Ok(placeRequest.Id) : Results.BadRequest();
      })
      .WithDisplayName("PutPlace")
      .WithTags("Places")
      .WithApiVersionSet(versionSet)
      .MapToApiVersion(1)
      .RequireAuthorization();;

      group.MapDelete("{id}", async (IPlacesApplication placesApplication, int id) =>
      {
         var place = placesApplication.RemovePlace(id);

         return place is true ? Results.Ok(true) : Results.BadRequest();
      })
      .WithDisplayName("DeletePlace")
      .WithTags("Places")
      .WithApiVersionSet(versionSet)
      .MapToApiVersion(1)
      .RequireAuthorization();;
   }
}
