using Lab1.Domain.Core.Interfaces;

namespace Lab1.Domain.Core
{
    public class Check: IIdenifiable
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
    }
}
