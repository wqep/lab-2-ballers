using Lab1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

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
                return $"Id:{Id}\r\nName: {Name}\r\nWallet: None";
            }
            return $"Id:{Id}\r\nName: {Name}\r\nWallet: {Wallet.ToString()}";
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
}
