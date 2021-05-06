using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;

namespace API.Application.Queries
{
    public interface IAirportQueries
    {
        Task<List<Airport>> GetAirports();
    }
}