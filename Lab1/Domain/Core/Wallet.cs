using System.Runtime.CompilerServices;
using Lab1.Domain.Core.Interfaces;

namespace Lab1.Domain.Core
{
    public class Wallet : IIdenifiable, IComparable
    {
        public string Id { get; }
        public User User { get; }
        public decimal Balance { get; set; }
        public Wallet (string id, User user, decimal balance)
        {
            Id = id;
            User = user;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Wallet Id: {Id}, balance: {Balance}";
        }
        
        public int CompareTo(object? obj)
        {
            if (obj is not Wallet other)
            {
                throw new ArgumentException("Object must be type of Wallet");
            }
            
            return this.Balance.CompareTo(other.Balance);
        }
    }
}
