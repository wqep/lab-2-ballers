using Lab1.Domain.Core.Interfaces;

namespace Lab1.Domain.Core
{
    public class Check: IIdenifiable, IComparable
    {
        public string Id { get; }
        public DateTime PaymentTime { get; } = DateTime.Now;
        public Ticket Ticket { get; }
        public string Status { get; }
        public Wallet Wallet { get; }
        public Check(string id, Ticket ticket, string status)
        {
            Id = id;
            Ticket = ticket;
            Status = status;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Operation time: {PaymentTime}, Status: {Status}";
        }

        public int CompareTo(object? obj)
        {
            if (obj is not Check other)
            {
                throw new ArgumentException("Object must be type of Check");
            }
            
            return string.Compare(Id, other.Id, StringComparison.OrdinalIgnoreCase);
        }
    }
}
