using Lab1.Domain.Core.Interfaces;

namespace Lab1.Domain.Core
{
    class User : IIdenifiable
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
    }
}
