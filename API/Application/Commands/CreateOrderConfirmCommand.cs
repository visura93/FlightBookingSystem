using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderConfirmCommand : IRequest<Order>
    {

            //public string FlightNo { get; private set; }

            //public string UserName { get; private set; }
            //public DateTime ArrivalDate { get; private set; }
            public bool OrderStatus { get; private set; }
           // public int NoOfSeats { get; private set; }
        
             public Guid Id { get; private set; }
        public CreateOrderConfirmCommand(Guid id,bool orderStatus)
            {
                //FlightNo = flightNo;
                //UserName = userName;
                //ArrivalDate = arrivalDate;
                OrderStatus = orderStatus;
                Id = id;
            }
        }
    }


