using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace API.Application.Commands
{
    public class CreateOrderConfirmCommandHandler : IRequestHandler<CreateOrderConfirmCommand, Order>
    {
  
            private readonly IOrderRepository _orderRepository;

            public CreateOrderConfirmCommandHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<Order> Handle(CreateOrderConfirmCommand request, CancellationToken cancellationToken)
            {
                var airport = _orderRepository.Update(new Order(request.Id, Guid.NewGuid(), null, DateTime.Now.Date, 0, request.OrderStatus));

                await _orderRepository.UnitOfWork.SaveChangesAsync();

                return airport;
            }

        
    }
}



