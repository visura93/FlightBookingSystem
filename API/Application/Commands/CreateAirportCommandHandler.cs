using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.AirportAggregate;
using MediatR;

namespace API.Application.Commands
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Airport>
    {
        private readonly IorderRepository _orderRepository;

        // This constructor takes an instance of an object that implements the IorderRepository interface and
        // stores it in the private _orderRepository field.
        public CreateAirportCommandHandler(IorderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // This method is called when a request of type CreateAirportCommand is received by the MediatR pipeline.
        public async Task<Airport> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = _orderRepository.Add(new Airport(request.Code, request.Name));
           
            // Save the changes to the database using the repository's UnitOfWork and the SaveEntitiesAsync method.
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            
            return airport;
        }
    }
}