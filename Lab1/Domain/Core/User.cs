using Lab1.Domain.Core.Interfaces;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Core;
>>>>>>> d61e295 (Tests.)

public class User : IIdenifiable
{
    public string Id { get; }
    public string Name { get; }
    public Wallet Wallet { get; set; }
    public User(string id, string name)
    {
<<<<<<< HEAD
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
=======
        Id = id;
        Name = name;
>>>>>>> d61e295 (Tests.)
    }
    public override string ToString()
    {
        if (Wallet == null)
        {
            return $"Id:{Id} Name: {Name} Wallet: None";
        }
        return $"Id:{Id} Name: {Name} Wallet: {Wallet.ToString()}";
    }
    public override bool Equals(object? obj)
    {
        if (obj is not User || obj == null)
        {
            return false;
        }
        return Id.Equals(((User)obj).Id);
    }
}