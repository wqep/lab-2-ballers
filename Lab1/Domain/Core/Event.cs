using Lab1.Domain.Core.Interfaces;

namespace Lab1.Domain.Core
{
    public class Event : IIdenifiable, IComparable
    {
        public string Id { get; }
        public string Name { get; }
        public string Status { get; set; } = "Planned";
        public DateTime DT { get; }
        public Event (string id, string name, DateTime dT)
        {
            Id = id;
            Name = name;
            DT = dT;
        }
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Status: {Status} Scheduled: {DT}\r\n";
        }
        
        public int CompareTo(object? obj)
        {
            if (obj is not Event other)
            {
                throw new ArgumentException("Object must be type of Event");
            }
            
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
