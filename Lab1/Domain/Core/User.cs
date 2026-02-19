using Lab1.Domain.Core.Interfaces;

namespace Lab1.Domain.Core
{
    public class User : IIdenifiable, IComparable
    {
        public string Id { get; }
        public string Name { get; }
        public Wallet Wallet { get; set; }
        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            if (Wallet == null)
            {
                return $"Id:{Id} Name: {Name} Wallet: None";
            }
            return $"Id:{Id} Name: {Name} Wallet: {Wallet.ToString()}";
        }
        
        public int CompareTo(object obj)
        {
            if (obj is not User other)
            {
                throw new ArgumentException("Object must be type of User");
            }
            
            return this.Wallet.Balance.CompareTo(other.Wallet.Balance);
        }
    }
}
