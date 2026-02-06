using Lab1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class User : IIdenifiable
    {
        public string Id { get; }
        public string Name { get; }
        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
