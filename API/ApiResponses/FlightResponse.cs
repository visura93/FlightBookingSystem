using Domain.Aggregates.FlightAggregate;
using System;
using System.Collections.Generic;

namespace API.ApiResponses;

public record FlightResponse(DateTimeOffset Arrival, DateTimeOffset Departure, Guid DestinationAirportId,string DomainEvents, Guid Id ,Guid OrigionalAirportId , List<FlightRate> Rates);