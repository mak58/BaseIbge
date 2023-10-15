using BaseIbge.Application.Dto;

namespace BaseIbge.Application.Interfaces;

public interface IPlacesApplication
{
    Task<PlaceDto> GetByIdAsync(int Id);
    Task<PlaceDto> GetByCityAsync(string city);
    Task<PlaceDto> GetByStateAsync(int state);

    void AddPlace(PlaceDto place);
    void UpdatePlace(int id, PlaceDto place);
    void RemovePlace(int id);    
}
