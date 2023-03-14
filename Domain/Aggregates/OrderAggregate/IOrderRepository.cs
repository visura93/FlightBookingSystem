using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
   public interface IOrderRepository : IRepository<Order>
    {
            Order Add(Order flight);
            Order Update(Order flight);

        }
    }

