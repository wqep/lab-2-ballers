using Lab1.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.App
{
    class DemoDataFactory
    {
        public DemoDataFactory() { }

        public User UserFactory(int number)
        {
            User user = new User("user" + number, "Max" + number);
            return user;
        }

        public void WalletFactory(int number, User user)
        {
            Random rnd = new Random();
            Wallet wallet = new Wallet("wallet" + number, user, rnd.Next(2000));
        }

        public void EventFactory(int number)
        {
            Event @event = new Event("event");
        }
    }
}
