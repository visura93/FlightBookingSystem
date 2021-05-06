using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Queries
{
    public class AirportQueries : IAirportQueries
    {
        private readonly FlightsContext _flightsContext;

        public AirportQueries(FlightsContext flightsContext)
        {
            _flightsContext = flightsContext;
        }
        
        public Task<List<Airport>> GetAirports()
        {
            return _flightsContext.Airports.ToListAsync();
        }
    }
}