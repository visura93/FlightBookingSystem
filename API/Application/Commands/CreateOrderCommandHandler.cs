using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Aggregates.OrderAggregate;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        

            private readonly IOrderRepository _orderRepository;

            public CreateOrderCommandHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var airport = _orderRepository.Add(new Order(Guid.NewGuid(), request.FlightNo, request.UserName,request.ArrivalDate , request.NoOfSeats));

                await _orderRepository.UnitOfWork.SaveEntitiesAsync();

                return airport;
            }
        }
    }

