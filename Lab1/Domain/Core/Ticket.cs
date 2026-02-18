using Lab1.Domain.Core.Interfaces;
namespace Lab1.Domain.Core;

public class Ticket : SellableItemBase, IIdenifiable, IReceiptLine
{
    public string Id { get; }
    public Event eVent { get; }
    public User Owner { get; set; }
    public decimal Price { get; set; }
    public Ticket(string id, Event evEnt, User owner, string name, decimal basePrice) : base(name, basePrice)
    {
<<<<<<< HEAD
        public string Id { get; }
        public Event eVent { get; }
        public User Owner { get; set; }
        public decimal Price { get; set; } 
        public Ticket (string id, Event evEnt, User owner, string name, decimal basePrice) : base(name, basePrice)
        {
            Id = id;
            Owner = owner;
            eVent = evEnt;
            Price = base.BasePrice;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Ticket || obj == null)
            {
                return false;
            }
            return Id.Equals(((Ticket)obj).Id);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Owner, Price);
        }

        public string PrintCheck()
        {
            return $"Id: {Id} Event: {eVent.Name} Price: {BasePrice} Buyer: {Owner.Name}";
        }
=======
        Id = id;
        Owner = owner;
        eVent = evEnt;
        Price = base.BasePrice;
>>>>>>> d61e295 (Tests.)
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Ticket || obj == null)
        {
            return false;
        }
        return Id.Equals(((Ticket)obj).Id);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Owner, Price);
    }
    public string PrintCheck()
    {
        return $"Id: {Id} Event: {eVent.Name} Price: {BasePrice} Buyer: {Owner.Name}";
    }
}