using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;
using System.Threading.Tasks;

namespace Modsen.App.DataAccess.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Transport> _dbSet;

        public TransportRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Transport>();
        }

        public async Task<Transport> GetByNameWithTrackingAsync(string name)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Name == name);

            return result;
        }
    }
}