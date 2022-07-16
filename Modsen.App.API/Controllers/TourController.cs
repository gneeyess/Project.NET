using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using Modsen.App.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;

namespace Modsen.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
            Log.Information("TourController constructed");
        }
        [HttpGet("id")]
        public async Task<TourDto> GetByIdAsync(int id)
        {
            return await _tourService.GetAsync(id);
        }

        [HttpGet("page")]
        public async Task<IEnumerable<TourShortDto>> GetPageAsync(int pageNumber = 0, int size = 0)
        {
            return await _tourService.GetQueueAsync(pageNumber, size);
        }
        //[Authorize(Roles = "admin")]
        [HttpPost("add")]
        public async Task AddTourAsync(TourDto tourDto)
        {
            await _tourService.AddAsync(tourDto);
        }
        [HttpPut("edit")]
        public async Task EditTourAsync(TourDto tourDto)
        {
            await _tourService.UpdateAsync(tourDto);
        }
        [HttpDelete("id")]
        public async Task DeleteTourAsync(int id)
        {
            await _tourService.DeleteAsync(id);
        }
    }
}
