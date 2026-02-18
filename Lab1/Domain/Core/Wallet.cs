using Lab1.Domain.Core.Interfaces;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Core;
>>>>>>> d61e295 (Tests.)

public class Wallet : IIdenifiable
{
    public string Id { get; }
    public User uSer { get; }
    public decimal Balance { get; set; }
    public Wallet(string id, User user, decimal balance)
    {
<<<<<<< HEAD
        public string Id { get; }
        public User User { get; }
        public decimal Balance { get; set; }
        public Wallet (string id, User user, decimal balance)
        {
            Id = id;
            User = user;
            Balance = balance;
        }
=======
        Id = id;
        uSer = user;
        Balance = balance;
    }
>>>>>>> d61e295 (Tests.)

    public override string ToString()
    {
        return $"Wallet Id: {Id}, balance: {Balance}";
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Wallet || obj == null)
        {
<<<<<<< HEAD
            return $"Wallet Id: {Id}, balance: {Balance}";
        }
=======
            return false;
        }
        return Id.Equals(((Wallet)obj).Id);
>>>>>>> d61e295 (Tests.)
    }
}
