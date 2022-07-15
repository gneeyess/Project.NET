using Modsen.App.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.API.Services
{
    public class TourService : ITourService
    {
        public Task<IEnumerable<TourShortDto>> GetQueueAsync(int pageNumber, int pageSize)
        {
            return null; //fix
        }

        public Task<TourDto> GetAsync(int id)
        {
            return null; //fix
        }

        public Task AddAsync(TourDto tourDto)
        {
            return null; //fix
        }

        public Task UpdateAsync(TourDto tourDto)
        {
            return null; //fix
        }

        public Task DeleteAsync(int id)
        {
            return null; //fix
        }
    }
}