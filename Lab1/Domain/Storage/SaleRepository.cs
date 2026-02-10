using Lab1.Domain.Core;
using Lab1.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Storage
{
    class SaleRepository
    {
        Ticket[] tickets = new Ticket[500];
        private int _count = 0;

        public bool AddTicket(Ticket ticket, Wallet wallet)
        {
            if (tickets.Contains(ticket) || _count == 500 || wallet.Balance < ticket.BasePrice)
            {
                return false;
            }
            tickets[_count] = ticket;
            _count++;
            wallet.Balance -= ticket.BasePrice;
            return true;
        }
        public int GetTicketIndexById(string id)
        {
            for (int i = 0; i < _count; i++)
            {
                if (id == tickets[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }
        public Ticket GetTicketByID(string id)
        {
            for (int i = 0; i < _count; i++)
            {
                if (id == tickets[i].Id)
                {
                    return tickets[i];
                }
            }
            return null;
        }

        public bool SellTicket(Ticket ticket, Wallet wallet)
        {
            if (!(tickets.Contains(ticket)) || _count == 0)
            {
                return false;
            }
            int indexToDelete = GetTicketIndexById(ticket.Id);
            tickets[indexToDelete] = tickets[_count - 1]; 
            wallet.Balance += ticket.BasePrice;
            _count--;
            return true;
        }
        public void EventSummary(Event @event)
        {
            decimal revenue = 0;
            for (int i = 0; i < _count; i++)
            {
                if (tickets[i].eVent == @event)
                {
                    revenue += tickets[i].BasePrice;
                }
            }
            Console.WriteLine(@event.ToString() + $"Revenue: {revenue}");
        }
    }
}
