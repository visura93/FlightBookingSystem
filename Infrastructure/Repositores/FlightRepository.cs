using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRepository: IFlightRepository
    {

        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        public Flight Add(Flight airport)
        {
            return _context.Flights.Add(airport).Entity;
        }

        public void Update(Flight airport)
        {
            _context.Flights.Update(airport);
        }

        public async Task<Flight> GetAsync(Guid airportId)
        {
            return await _context.Flights.FirstOrDefaultAsync(o => o.Id == airportId);
        }
        public List<Flight> GetAvailableFlight(DateTimeOffset? departure, DateTimeOffset? arrival, Guid? originAirportId, Guid? destinationAirportId)
        {
            IQueryable<Flight> query = _context.Flights;

            if (departure.HasValue)
            {
                query = query.Where(f => f.Departure == departure.Value);
            }

            if (arrival.HasValue)
            {
                query = query.Where(f => f.Arrival == arrival.Value);
            }

            if (originAirportId.HasValue)
            {
                query = query.Where(f => f.OriginAirportId == originAirportId.Value);
            }

            if (destinationAirportId.HasValue)
            {
                query = query.Where(f => f.DestinationAirportId == destinationAirportId.Value);
            }

            return query.ToList();
        }


    }
}

