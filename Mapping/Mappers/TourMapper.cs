using AutoMapper;
using Dal.Entities;
using Modsen.App.Core.Models.Dto;

namespace Mapping.Mappers;

public class TourMapper : Profile
{
    public TourMapper()
    {
        CreateMap<Tour, TourShortDto>();
        CreateMap<Tour, TourDto>()
            .ReverseMap()
            .ForMember(dto => dto.TourType, expression => expression.Ignore())
            .ForMember(dto => dto.Transport, expression => expression.Ignore());
    }
}