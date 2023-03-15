using Domain.Aggregates.FlightAggregate;
using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
       
        public class Order : Entity, IAggregateRoot
        {
        
             public Guid FlightNo { get; private set; }

            public string UserName { get; private set; }
            public DateTime ArrivalDate { get; private set; }
            public int NoOfSeats { get; private set; }
            public Guid Id { get; set; }
            public bool OrderStatus { get; set; }
            
        public Order()
                {
                }

            public Order( Guid id , Guid flightNo, string userName, DateTime arrivalDate , int noOfSeats, bool orderStatus = false) : this()
            {

                FlightNo = flightNo;
                UserName = userName;
                ArrivalDate = arrivalDate;
                Id = id;
                NoOfSeats = noOfSeats;
                OrderStatus = orderStatus;
            }
        }
    }


