using BaseIbge.Application.Interfaces;
using BaseIbge.Domain.Interfaces;
using BaseIbge.Domain.ViewModels;
using BaseIbge.Infrastructure.Data;
using BasePlace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseIbge.Application;

public class PlacesApplication : IPlacesApplication
{     
    #region /// DI and Ctor 
        private readonly IPlaceRepository _placeRepository;

        public PlacesApplication(IPlaceRepository placeRepository)
            =>  _placeRepository = placeRepository;        

    #endregion            

    /// <summary>
    /// Methods that calls database context to store, retrieve, fetch, update etc...
    /// </summary>
    /// <param name="placeRequest"></param>
    /// Class that input data from frontEnd
    /// <returns name="Place"></returns>
    /// Class Place containning data from places in the database.
    public async Task<Place> AddPlaceAsync(PlaceRequest placeRequest)
    {
        var place = placeRequest.MapTo();
        if (!placeRequest.IsValid) return null;

        await _placeRepository.PostAsync(place);
        
        return place;
    }

    public async Task<List<Place>> GetAsync()
    {
        var places = await _placeRepository.GetPlaceAsync();
        return places;
    }


    public async Task<List<Place>> GetByCityAsync(string city)
    {
        var place = await _placeRepository.GetPlaceByCity(city);
        return place;
    }

    public async Task<Place> GetByIdAsync(int id)
    {
        var place = await _placeRepository.GetPlaceById(id);
        return place;
    }

    public async Task<List<Place>> GetByStateAsync(string state)
    {
        var place = await _placeRepository.GetPlaceByState(state);
        return place;
    }

    public async Task<Place> UpdatePlaceAsync(PlaceRequest placeRequest, int id)
    {
        var place = await _placeRepository.GetPlaceById(id);
        if (place is null) return null;

        placeRequest.MapTo();
        if (!placeRequest.IsValid) 
               return null;
        
        Place newPlace = new(placeRequest.Id, placeRequest.City, placeRequest.State);

        _placeRepository.PutAsync(newPlace);
 
        return newPlace;     
    }

        public bool RemovePlace(int id)
    {
        return _placeRepository.Remove(id).Result;        
    }
}
