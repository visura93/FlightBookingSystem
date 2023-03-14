using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Flight Add(Flight flight);

        void Update(Flight flight);

        Task<Flight> GetAsync(Guid flightId);
        Flight GetAvailableFlight(DateTimeOffset departure, DateTimeOffset arrival, Guid originAirportId, Guid destinationAirportId);
    }
}