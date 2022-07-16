using AutoMapper;
using Dal.Entities;
using Modsen.App.Core.Models.Dto;

namespace Mapping.Mappers
{
    public class TourTypeMapper : Profile
    {
        public TourTypeMapper()
        {
            CreateMap<TourType, TourTypeDto>();
        }
    }
}