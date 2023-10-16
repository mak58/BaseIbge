using AutoMapper;
using BaseIbge.Application.Dto;
using BaseIbge.Application.Interfaces;
using BaseIbge.Domain.Interfaces;

namespace BaseIbge.Application;

public class PlacesApplication : IPlacesApplication
{
    private readonly IPlaceRepository _placeRepository;
    private readonly IRepositoryBase<PlaceDto> _repositoryBase;
    private readonly IMapper _mapper;


    public PlacesApplication(
        IPlaceRepository placeRepository,
        IRepositoryBase<PlaceDto> repositoryBase,
        IMapper mapper)
    {
        _placeRepository = placeRepository;
        _repositoryBase = repositoryBase;
        _mapper = mapper;

    }

    public void AddPlace(PlaceDto place)
    {
        _repositoryBase.Insert(place);
    }

    public Task<PlaceDto> GetByCityAsync(string city)
    {
        throw new NotImplementedException();
    }

    public Task<PlaceDto> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<PlaceDto> GetByStateAsync(int state)
    {
        throw new NotImplementedException();
    }

    public void RemovePlace(int id)
    {
        var entity = _repositoryBase.Get(id);
        

        if (entity is not null)
            _repositoryBase.Remove(_mapper.Map<PlaceDto>(entity));
    }

    public void UpdatePlace(int id, PlaceDto place)
    {
        throw new NotImplementedException();
    }

}
