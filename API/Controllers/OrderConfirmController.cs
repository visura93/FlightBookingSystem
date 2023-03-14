using API.Application.Commands;
using API.Application.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderConfirmController : ControllerBase
    {
     
            private readonly ILogger<AirportsController> _logger;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public OrderConfirmController(
                ILogger<AirportsController> logger,
                IMediator mediator,
                IMapper mapper)
            {
                _logger = logger;
                _mediator = mediator;
                _mapper = mapper;
            }

            [HttpPut]
            [Route("OrderAggregateConfirm")]
            public async Task<IActionResult> ConfirmOrder([FromBody] CreateOrderConfirmCommand command)
            {
                try
                {
                    var airport = await _mediator.Send(command);

                    return Ok(airport);
                }
                catch
                {
                    return BadRequest();
                }
            }
        }

    }



