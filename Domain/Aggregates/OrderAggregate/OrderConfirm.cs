using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public class OrderConfirm : Entity, IAggregateRoot
    {
     
            public string FlightNo { get; private set; }

            public string UserName { get; private set; }
            public DateTime ArrivalDate { get; private set; }
             public bool OrderStatus { get; private set; }
             public Guid Id { get; set; }

        public OrderConfirm()
            {
            }

            public OrderConfirm(Guid id, string flightNo, string userName, DateTime arrivalDate, bool orderStatus) : this()
            {
                Id= id;
                FlightNo = flightNo;
                UserName = userName;
                ArrivalDate = arrivalDate;
                OrderStatus = orderStatus;
            }
        }
    }


