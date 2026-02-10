using Lab1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class Wallet : IIdenifiable
    {
        public string Id { get; }
        public User uSer { get; }
        public decimal Balance { get; set; }
        public Wallet (string id, User user, decimal balance)
        {
            Id = id;
            uSer = user;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Wallet Id: {Id}\r\n owner: {uSer.Name}, {uSer.Id}\r\n balance: {Balance}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Wallet || obj == null)
            {
                return false;
            }
            return Id.Equals(((Wallet)obj).Id);
        }
    }
}
