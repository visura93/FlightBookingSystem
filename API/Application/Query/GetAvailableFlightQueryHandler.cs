using API.Application.Commands;
using Domain.Aggregates.AirportAggregate;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Aggregates.FlightAggregate;
using System;
using System.Collections.Generic;

namespace API.Application.Query
{
    public class GetAvailableFlightQueryHandler : IRequestHandler<GetAvailableFlightQuery, List<Flight>>
    {
       
            private readonly IFlightRepository _flightRepository;

            public GetAvailableFlightQueryHandler(IFlightRepository flightRepository)
            {
            _flightRepository = flightRepository;
            }

           

        public async Task<List<Flight>> Handle(GetAvailableFlightQuery request, CancellationToken cancellationToken)
        {
            var airport = _flightRepository.GetAvailableFlight(request.Departure, request.Arrival, request.OriginAirportId, request.DestinationAirportId);

            await _flightRepository.UnitOfWork.SaveEntitiesAsync();

            return airport;
        }
    }
    }

