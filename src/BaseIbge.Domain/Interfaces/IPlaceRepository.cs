using BasePlace.Domain.Models;

namespace BaseIbge.Domain.Interfaces;

public interface IPlaceRepository
{
    Task<Place> GetPlaceByCity(string city);
    Task<Place> GetPlaceByState(string city);
    Task<Place> GetPlaceById(int id);
    Task<Place> GetPlaceAsync();
    Task<Place> PostAsync(Place place);
    Task<Place> PutAsync(int id, Place place);
    Task<bool> Remove(int id);
    Task<bool> SaveChangesAsync();





}
