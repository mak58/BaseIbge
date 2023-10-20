using BaseIbge.Domain.Interfaces;
using BaseIbge.Infrastructure.Data;
using BasePlace.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseIbge.Infrastructure.Repositories;

public class PlaceRepository : IPlaceRepository
{
    private readonly AppDbContext _context;
    public PlaceRepository(AppDbContext context)
        => _context = context;        

    public async Task<List<Place>> GetPlaceAsync()
    {
        var places = _context.Places.AsNoTracking().ToList();
        return places;
    }

    public async Task<List<Place>> GetPlaceByCity(string city)
    {
        var place = _context.Places.Where(x => x.City == city).ToList();
        return place;
    }

    public async Task<Place> GetPlaceById(int id)
    {
       var place = _context.Places.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        _context.SaveChanges();

        return place;
    }

    public async Task<List<Place>> GetPlaceByState(string state)
    {
        var place = _context.Places.Where(x => x.State == state).ToList();
        return place;
    }

    public async Task<Place> PostAsync(Place place)
    {
        _context.Places.Add(place);
        _context.SaveChanges();

        return place;
    }

    public async Task<Place> PutAsync(Place place)
    {
        _context.Places.Update(place);
        _context.SaveChanges();

        return place;
    }

    public async Task<bool> Remove(int id)
    {
        var place = _context.Places.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();

        if(place is null) return false;

        _context.Remove(place);
        return _context.SaveChanges() > 0;
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}
