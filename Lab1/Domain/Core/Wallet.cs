using Lab1.Domain.Core.Interfaces;

namespace Lab1.Domain.Core
{
    class Wallet : IIdenifiable
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
    }
}
