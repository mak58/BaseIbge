using BaseIbge.Domain.ViewModels;
using BasePlace.Domain.Models;

namespace BaseIbge.Application.Interfaces;

public interface IPlacesApplication
{
    Task<List<Place>> GetAsync();
    Task<Place> GetByIdAsync(int id);
    Task<List<Place>> GetByCityAsync(string city);
    Task<List<Place>> GetByStateAsync(string state);

    Task<Place> AddPlaceAsync(PlaceRequest placeRequest);
    Task<Place> UpdatePlaceAsync(PlaceRequest place, int id);
    bool RemovePlace(int id);    
}
