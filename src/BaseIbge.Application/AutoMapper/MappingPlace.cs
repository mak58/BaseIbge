using AutoMapper;
using BaseIbge.Application.Dto;
using BasePlace.Domain.Models;

namespace BaseIbge.Application.AutoMapper;

public class MappingPlace : Profile
{
    protected MappingPlace()
    {
        CreateMap<PlaceDto, Place>()
            .ReverseMap();
    }
}
