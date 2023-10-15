using BasePlace.Domain.Models;

namespace BaseIbge.Domain.Interfaces;

public interface IPlaceRepository
{
    Task<Place> GetPlaceByCity(string city);
    Task<Place> GetPlaceByState(string city);

}
