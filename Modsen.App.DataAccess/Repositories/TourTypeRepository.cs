using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class TourTypeRepository : ITourTypeRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TourType> _dbSet;

        public TourTypeRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TourType>();
        }
        public async Task<TourType> GetByNameWithTrackingAsync(string name)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);

            return result;
        }

    }
}