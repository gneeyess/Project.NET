using AutoMapper;
using Dal.Entities;
using Modsen.App.Core.Models.Dto;

namespace Mapping.Mappers;

public class TransportMapper :Profile
{
    public TransportMapper()
    {
        CreateMap<Transport, TransportDto>();
    }
}