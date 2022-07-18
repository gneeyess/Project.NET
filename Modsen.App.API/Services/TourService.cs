using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dal.Entities;
using FluentValidation.Results;
using Modsen.App.Core.Models.Dto;
using Modsen.App.Core.Services;
using Modsen.App.DataAccess.Abstractions;
using Validation.Validators;

namespace Modsen.App.API.Services
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TourValidator _tourValidator;
        public TourService(IUnitOfWork unitOfWork, IMapper mapper, TourValidator tourValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tourValidator = tourValidator;
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

            var validationResult = await _tourValidator.ValidateAsync(tour);

            if (validationResult.IsValid)
            {
                await _unitOfWork.TourRepository.AddAsync(tour);
            }

            
        }
        public async Task UpdateAsync(TourDto tourDto)
        {
            var tour = _mapper.Map<TourDto, Tour>(tourDto);

            tour.TransportId = tourDto.TourType.Id;
            tour.TourTypeId = tourDto.Transport.Id;

            var validationResult = await _tourValidator.ValidateAsync(tour);

            if (validationResult.IsValid)
            {
                await _unitOfWork.TourRepository.UpdateAsync(tour);
            }
            

        }
        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TourRepository.DeleteByIdAsync(id);
        }


    }
}