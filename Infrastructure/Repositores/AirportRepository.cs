using System;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositores
{
    public class orderRepository : IorderRepository
    {
        private readonly FlightsContext _context;
        
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public orderRepository(FlightsContext context)
        {
            _context = context;
        }
        
        public Airport Add(Airport airport)
        {
            return _context.Airports.Add(airport).Entity;
        }

        public void Update(Airport airport)
        {
            _context.Airports.Update(airport);
        }

        public async Task<Airport> GetAsync(Guid airportId)
        {
            return await _context.Airports.FirstOrDefaultAsync(o => o.Id == airportId);
        }
    }
}