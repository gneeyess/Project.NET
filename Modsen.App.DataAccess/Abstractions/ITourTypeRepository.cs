using System.Threading.Tasks;
using Dal.Entities;

namespace Modsen.App.DataAccess.Abstractions;

public interface ITourTypeRepository
{
    Task<TourType> GetByNameWithTrackingAsync(string name);
}