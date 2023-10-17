using BaseIbge.Application.Interfaces;
using BaseIbge.Domain.ViewModels;
using BaseIbge.Infrastructure.Data;
using BasePlace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseIbge.Application;

public class PlacesApplication : IPlacesApplication
{
 
    private readonly AppDbContext _context;

    public PlacesApplication(AppDbContext context)
        => _context = context;


    public async Task<Place> AddPlace(Place place)
    {
        // _placeRepository.PostAsync(place);
        _context.Places.Add(place);
        await _context.SaveChangesAsync();

        return place;
    }

    public async Task<List<Place>> GetByCityAsync(string city)
    {
        var place = _context.Places.Where(x => x.City == city).ToList();
        return place;
    }

    public Place GetById(int id)
    {
        var place =  _context.Places.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        return place;
    }

    public async Task<List<Place>> GetByState(string state)
    {
        var place = _context.Places.Where(x => x.State == state).ToList();
        return place;
    }

    public bool RemovePlace(int id)
    {
        var place = _context.Places.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

        if(place is null) return false;

        _context.Places.Remove(place);
        _context.SaveChanges();
        return true;
    }

    public async Task<Place> UpdatePlace(PlaceRequest placeRequest, int id)
    {
        var place = GetById(id);
        Place newPlace = new(placeRequest.Id, placeRequest.State, placeRequest.City);

        if(place is not null)
        {            
            _context.Places.Update(newPlace);
            _context.SaveChanges();
        }   
        return newPlace;     
    }
}
