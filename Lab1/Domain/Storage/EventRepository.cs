using Lab1.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Storage
{
    class EventRepository
    {
        Event[] events = new Event[50];
        private int _count;

        public bool AddEvent(Event evenT)
        {
            if (events.Contains(evenT) || _count == 50)
            {
                return false;
            }
            events[_count] = evenT;
            _count++;
            return true;
        }
        public Event GetEventById(string id)
        {
            for (int i = 0; i < _count; i++)
            {
                if (id == events[i].Id)
                {
                    return events[i];
                }
            }
            return null;
        }

        public void PrintAll()
        {
            if (_count == 0)
            {
                Console.WriteLine("Create some first");
            }
            else
            {
                for (int i = 0; i < _count; i++)
                {
                    Console.WriteLine(events[i].ToString());
                }
            }
        }
    }
}
