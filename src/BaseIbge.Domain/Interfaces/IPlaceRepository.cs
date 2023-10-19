using BasePlace.Domain.Models;

namespace BaseIbge.Domain.Interfaces;

public interface IPlaceRepository
{
    Task<List<Place>> GetPlaceByCity(string city);
    Task<List<Place>> GetPlaceByState(string state);
    Task<Place> GetPlaceById(int id);
    Task<List<Place>> GetPlaceAsync();
    Task<Place> PostAsync(Place place);
    Task<Place> PutAsync(Place place);
    Task<bool> Remove(Place place);
    bool SaveChanges();





}
