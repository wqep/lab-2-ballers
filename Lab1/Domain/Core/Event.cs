using Lab1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class Event : IIdenifiable
    {
        public string Id { get; }
        public string Name { get; }
        public string Status { get; set; } = "Planned";
        public DateTime DT { get; }
        
        public Event (string id)
        {
            Id = id;
        }
        public Event (string id, string name, DateTime dT)
        {
            Id = id;
            Name = name;
            DT = dT;
        }
        public override string ToString()
        {
            return $"Id: {Id}\r\nName: {Name}\r\nStatus: {Status}\r\nScheduled: {DT}\r\n";
        }
    }
}
