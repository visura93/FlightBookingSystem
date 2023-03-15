using System;
using System.Linq;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Infrastructure;

namespace API.Infrastructure.Seeds
{
    public class FlightsSeeder : FlightsContextSeeder
    {
        public FlightsSeeder(FlightsContext flightsContext) : base(flightsContext)
        {
        }

        public override void Seed()
        {
            if (FlightsContext.Flights.Any())
            {
                Console.WriteLine("Skipping Flights seeder because table is not empty.");
                return;
            };

            for (int i = 0; i < 500; i++)
            {
                var random = new Random();
                var randomSkip = random.Next(0, FlightsContext.Airports.Count() - 2);
                var twoRandomAirports = FlightsContext.Airports.OrderBy(o => o.Id).Skip(randomSkip).Take(2).ToList();

                var departure = new DateTimeOffset(
                    random.Next(2021, 2023), random.Next(1, 12), 01, random.Next(0, 23),
                    random.Next(0, 59), 0, TimeSpan.Zero);
                var availableSeats = random.Next(23, 201);
                FlightsContext.Flights.Add(new Flight(
                    departure,
                    departure.AddHours(random.Next(1, 16)),
                    twoRandomAirports[0].Id,
                    twoRandomAirports[1].Id,
                    availableSeats
                ));
            }
            if (FlightsContext.Orders.Any())
            {
                Console.WriteLine("Skipping Orders seeder because table is not empty.");
                return;
            };
            FlightsContext.Orders.Add(new Order());
            FlightsContext.SaveChanges();
        }
    }
}