using System.Collections.Generic;
using System.Threading.Tasks;
using Dal.Entities;

namespace Modsen.App.DataAccess.Abstractions;

public interface ITransportRepository
{
    Task<Transport> GetByNameWithTrackingAsync(string name);
}