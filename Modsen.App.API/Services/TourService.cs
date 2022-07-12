using AutoMapper;
using Dal.Entities;
using Modsen.App.Core.Models.Dto;
using Modsen.App.Core.Services;
using Modsen.App.DataAccess.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modsen.App.API.Services
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TourService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TourDto> GetAsync(int id)
        {
            var tour = await _unitOfWork.TourRepository.GetByIdWithTrackingAsync(id);
            

            return tour;
        }

        public async Task<IEnumerable<TourShortDto>> GetQueueAsync(int pageNumber, int pageSize)
        {
            var result = await _unitOfWork.TourRepository.GetQueueAsync(pageNumber, pageSize);

            return result;
        }

        public async Task AddAsync(TourDto tourDto)
        {
            var tour = _mapper.Map<TourDto, Tour>(tourDto);

            tour.TransportId = tourDto.TourType.Id;
            tour.TourTypeId = tourDto.Transport.Id;

            await _unitOfWork.TourRepository.AddAsync(tour);
        }
        public async Task UpdateAsync(TourDto tourDto)
        {
            var tour = _mapper.Map<TourDto, Tour>(tourDto);

            tour.TransportId = tourDto.TourType.Id;
            tour.TourTypeId = tourDto.Transport.Id;

            await _unitOfWork.TourRepository.UpdateAsync(tour);

        }
        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TourRepository.DeleteByIdAsync(id);
        }


    }
}