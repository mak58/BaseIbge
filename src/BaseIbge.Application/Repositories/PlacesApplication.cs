using BaseIbge.Application.Interfaces;
using BaseIbge.Domain.Interfaces;
using BaseIbge.Domain.ViewModels;
using BaseIbge.Infrastructure.Data;
using BasePlace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseIbge.Application;

public class PlacesApplication : IPlacesApplication
{ 
    private readonly AppDbContext _context;
        private readonly IPlaceRepository _placeRepository;

    public PlacesApplication(AppDbContext context, IPlaceRepository repo)
    {        
        _context = context;
        _placeRepository = repo;
    }

    public IPlaceRepository Repo { get; }


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
        var place = _context.Places.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

        if(place is null) return false;

        return _placeRepository.Remove(place).Result;
        
    }
}
