using Lab1.Domain.Core;
namespace Lab1.App;

public class DemoDataFactory
{
    public DemoDataFactory()
    {

    }

    public User UserFactory(int number)
    {
        return new User("user" + number, "Max" + number);
    }

    public Wallet WalletFactory(int number, User user)
    {
        Random rnd = new Random();
        return new Wallet("wallet" + number, user, rnd.Next(2000));
    }

    public Event EventFactory(int number, DateTime dt)
    {
        return new Event("event" + number, "concert" + number, dt);
    }
}