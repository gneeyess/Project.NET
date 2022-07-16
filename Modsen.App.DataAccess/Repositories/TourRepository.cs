using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Modsen.App.Core.Models.Dto;

namespace Modsen.App.DataAccess.Repositories
{
    public class TourRepository : IRepository<Tour>
    //, ITourRepository, конфликт по методу GetQueueAsync
    //Если убрать наследование от интерфейса IRepository<Tour> 
    //То error в startup.cs
    //Возвращаемый тип другой
    //Это вызывает ошибку в AddScoped......................
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Tour> _dbSet;
        private readonly IMapper _mapper;
        //1
        public TourRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<Tour>();
            _mapper = mapper;
        }
        //2
        public async Task<Tour> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        //3
        public async Task<IEnumerable<Tour>> GetQueueAsync(int offset, int size)
        {
            var result = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).ToListAsync();

            return result;
        }
        //3.2

        //It is different. Just as is.
        //It calls some errors
        //becouse return type not as in IRepository inteface

        /*      public async Task<IEnumerable<TourShortDto>> GetQueueAsync(int offset, int size)
                {
                    var queue = await _dbSet.AsNoTracking().Skip(offset * size).Take(size).Select(c => _mapper.Map<TourShortDto>(c)).ToListAsync();

                    return queue;
                }*/

        //4
        public async Task DeleteAsync(int id)
        {
            var item = await _dbSet.FindAsync(id);

            if (item != null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
        //4.2
        public async Task DeleteByIdAsync(int id)
        {
            var tour = await _dbSet.FindAsync(id);
            if (tour != null)
            {
                _dbSet.Remove(tour);
                await _context.SaveChangesAsync();
            }
        }
        //5
        public async Task UpdateAsync(Tour tour)
        {
            var toUpdateTourIsNotNull = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == tour.Id) != null;
            if (toUpdateTourIsNotNull)
            {
                _dbSet.Update(tour);
                await _context.SaveChangesAsync();
            }
        }
        //6
        public async Task AddAsync(Tour tour)
        {
            await _dbSet.AddAsync(tour);
            await _context.SaveChangesAsync();
        }

        public async Task<TourDto> GetByIdWithTrackingAsync(int id)
        {
            var tour = await _dbSet.FindAsync(id);
            var result = _mapper.Map<TourDto>(tour);

            return result;
        }
    }
}