using Domain.SeedWork;

namespace Domain.Aggregates.AirportAggregate
{
    public class Airport : Entity, IAggregateRoot
    {
        public string Code { get; private set; }

        public string Name { get; private set; }

        public Airport()
        {
        }
        
        public Airport(string code, string name) : this()
        {
            Code = code;
            Name = name;
        }
    }
}