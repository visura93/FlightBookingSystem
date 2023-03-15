using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System;

namespace API.Application.Query
{
    public class GetAvailableFlightQuery : IRequest<List<Flight>>
    {
        public Guid? OriginAirportId { get;  set; }
        public Guid? DestinationAirportId { get;  set; }

        public DateTimeOffset? Departure { get;  set; }
        public DateTimeOffset? Arrival { get;  set; }

        private List<FlightRate> _rates;
       // public IReadOnlyCollection<FlightRate> Rates => _rates;
       

            public GetAvailableFlightQuery(DateTimeOffset? departure , DateTimeOffset? arrival , Guid? originAirportId , Guid?
            destinationAirportId )
            {
            OriginAirportId = originAirportId;
            DestinationAirportId = destinationAirportId;
            Departure = departure;
            Arrival = arrival;
            }
        public GetAvailableFlightQuery()
        {
        }

    }
}
