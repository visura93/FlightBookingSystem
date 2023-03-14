using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Commands;
using API.Application.Query;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<AirportsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FlightsController(
        ILogger<AirportsController> logger,
        IMediator mediator,
        IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpGet]
    [Route("Search")]
    public async Task<IActionResult> GetAvailableFlights([FromQuery] GetAvailableFlightQuery filter)
    {
        try
        {
            var airport = await _mediator.Send(filter);
            if (airport == null)
            {
                return NotFound( "No flights available" );
            }
            else
            {
                return Ok(new
                {
                    IsSuccess = true,
                    Result = airport
                });
            }
        }
        catch
        {
            return BadRequest();
        }
    }
}
