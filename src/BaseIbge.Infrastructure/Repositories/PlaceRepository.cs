using BaseIbge.Domain.Interfaces;
using BaseIbge.Infrastructure.Data;
using BasePlace.Domain.Models;

namespace BaseIbge.Infrastructure.Repositories;

public class PlaceRepository : IPlaceRepository
{

    private readonly AppDbContext _context;

    public PlaceRepository(AppDbContext context)
    {
         context = _context; 
    }
                
    public Task<Place> GetPlaceAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Place> GetPlaceByCity(string city)
    {
        throw new NotImplementedException();
    }

    public Task<Place> GetPlaceById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Place> GetPlaceByState(string city)
    {
        throw new NotImplementedException();
    }

    public Task<Place> PostAsync(Place place)
    {
        _context.Places.Add(place);
        _context.SaveChangesAsync();

        return Task.FromResult(place);
    }

    public Task<Place> PutAsync(int id, Place place)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Remove(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

}
