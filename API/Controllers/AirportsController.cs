using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Application.Commands;
using API.Application.Queries;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IAirportQueries _airportQueries;

        public AirportsController(
            ILogger<AirportsController> logger,
            IMediator mediator,
            IMapper mapper,
            IAirportQueries airportQueries)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _airportQueries = airportQueries;
        }

        [HttpGet]
        public async Task<List<AirportViewModel>> Get()
        {
            var airports = await _airportQueries.GetAirports();
            
            return _mapper.Map<List<AirportViewModel>>(airports);
        }

        [HttpPost]
        public async Task<IActionResult> Store([FromBody]CreateAirportCommand command)
        {
            var airport = await _mediator.Send(command);

            return Ok(_mapper.Map<AirportViewModel>(airport));
        }
    }
}