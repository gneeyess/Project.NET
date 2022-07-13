using System.Collections.Generic;
using System.Threading.Tasks;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.Core.Services
{
    public interface ITourService
    {
        public Task<IEnumerable<TourShortDto>> GetQueueAsync(int pageNumber, int pageSize);
        public Task<TourDto> GetAsync(int id);
        public Task AddAsync(TourDto tourDto);
        public Task UpdateAsync(TourDto tourDto);
        public Task DeleteAsync(int id);
    }
}