using Lab1.Domain.Core.Interfaces;
using Lab1.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class Ticket : SellableItemBase, IIdenifiable, IReceiptLine
    {
        public string Id { get; }
        public Event eVent { get; }
        public User Owner { get; set; }
        public Ticket (string id, Event evEnt, string name, decimal basePrice) : base(name, basePrice)
        {
            Id = id;
            eVent = evEnt;
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Ticket || obj == null)
            {
                return false;
            }
            return Id.Equals(((Ticket)obj).Id);
        }
        public string PrintCheck()
        {
            return $"Id: {Id}\r\n Event: {eVent}\r\n Price: {BasePrice}\r\nBuyer: {Owner.Name}, {Owner.Id}";
        }
    }
}
