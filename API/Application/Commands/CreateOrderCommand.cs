using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {

        public string FlightNo { get; private set; }

        public string UserName { get; private set; }
        public DateTime ArrivalDate { get; private set; }
        public bool OrderStatus { get; private set; }

        public CreateOrderCommand( string flightNo, string userName, DateTime arrivalDate, bool orderStatus)
            {
                FlightNo = flightNo;
                UserName = userName;    
                ArrivalDate = arrivalDate;
                OrderStatus = orderStatus;
               
            }
        }
 }


