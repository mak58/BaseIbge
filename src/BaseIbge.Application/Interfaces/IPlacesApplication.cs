using BaseIbge.Domain.ViewModels;
using BasePlace.Domain.Models;

namespace BaseIbge.Application.Interfaces;

public interface IPlacesApplication
{
    Place GetById(int id);
    Task<List<Place>> GetByCityAsync(string city);
    Task<List<Place>> GetByState(string state);

    Task<Place> AddPlace(Place place);
    Task<Place> UpdatePlace(PlaceRequest place, int id);
    bool RemovePlace(int id);    
}
