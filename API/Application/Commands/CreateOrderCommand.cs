using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {

        public Guid FlightNo { get; private set; }

        public string UserName { get; private set; }
        public DateTime ArrivalDate { get; private set; }
        public int NoOfSeats { get; private set; }
       

        public CreateOrderCommand(Guid flightNo, string userName, DateTime arrivalDate, int noOfSeats)
            {
                FlightNo = flightNo;
                UserName = userName;    
                ArrivalDate = arrivalDate;
                NoOfSeats = noOfSeats;

            }
        }
 }


