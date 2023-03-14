using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
       
        public class Order : Entity, IAggregateRoot
        {
            public string FlightNo { get; private set; }

            public string UserName { get; private set; }
            public DateTime ArrivalDate { get; private set; }
            public bool OrderStatus { get;  set; }
             public Guid Id { get; set; }
        public Order()
            {
            }

            public Order( Guid id ,string flightNo, string userName, DateTime arrivalDate, bool orderStatus) : this()
            {

                FlightNo = flightNo;
                UserName = userName;
                ArrivalDate = arrivalDate;
                OrderStatus = orderStatus;
                Id = id;
            }
        }
    }


