using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
      
       

            private readonly FlightsContext _context;

            public IUnitOfWork UnitOfWork
            {
                get { return _context; }
            }

            public OrderRepository(FlightsContext context)
            {
                _context = context;
            }

            public Order Add(Order order)
            {
                return _context.Orders.Add(order).Entity;
            }

            public Order Update(Order order)
            {
            
                var savedOrder = _context.Orders.Where(o => o.Id == order.Id).SingleOrDefault();
                int currentAbailableSeats= 0;
            
            
                var savedFlight = _context.Flights.Where(o => o.Id == savedOrder.FlightNo).SingleOrDefault();
           
                currentAbailableSeats = savedFlight.AvailableSeats - savedOrder.NoOfSeats;
                if (currentAbailableSeats > -1)
                {
                    savedFlight.AvailableSeats = currentAbailableSeats;
                    var saved =_context.Flights.Update(savedFlight).Entity;
                    savedOrder.OrderStatus = order.OrderStatus;
                    return _context.Orders.Update(savedOrder).Entity;
                }
                else
                {
                    return new Order {  OrderStatus =false};
                }
                
            }

        }
    }



