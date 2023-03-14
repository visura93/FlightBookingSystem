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
        public  Flight GetAvailableFlight(DateTimeOffset departure, DateTimeOffset arrival, Guid originAirportId, Guid destinationAirportId)
        {
            return  _context.Flights.FirstOrDefaultAsync(o => o.DestinationAirportId == destinationAirportId && o.Departure== departure && o.Arrival == arrival && o.OriginAirportId == originAirportId).Result;
        }

        
    }
}

