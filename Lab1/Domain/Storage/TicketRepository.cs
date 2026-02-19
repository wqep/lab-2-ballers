using System.Collections;
using System.Data;
using Lab1.Domain.Core;
using Lab1.Domain.Core.Comparers;
using Lab1.Domain.Core.Enumerators;

namespace Lab1.Domain.Storage;

public class TicketRepository : IEnumerable
{
    public Ticket[] tickets = new Ticket[500];
    public int _count = 0;
    
    public int GetCount()
    {
        return _count;
    }
    
    public Ticket GetTicketById(string id)
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
    
    public bool AddTicket(Ticket ticket, Wallet wallet)
    {
        if (tickets.Contains(ticket) || _count == 500 || wallet.Balance < ticket.BasePrice || ticket.eVent.DT < DateTime.Now)
        {
            return false;
        }
        if (ticket.eVent.Status == "Ongoing")
        {
            ticket.Price *= (decimal)0.8;
        }
        ticket.Owner = wallet.User;
        tickets[_count] = ticket;
        wallet.Balance -= ticket.Price;
        
        _count++;

        return true;
    }
    
    public void EventSummary(Event @event)
    {
        decimal revenue = 0;
        for (int i = 0; i < _count; i++)
        {
            if (tickets[i].eVent == @event && tickets[i].Owner != null)
            {
                revenue += tickets[i].BasePrice;
            }
            if (tickets[i].eVent == @event && tickets[i].Owner == null)
            {
                revenue += tickets[i].BasePrice - tickets[i].BasePrice / (decimal)1.25;
            }
        }
        Console.WriteLine(@event.ToString() + $"Revenue: {revenue}");
    }
    
    public void PrintTicketsForUser(User user) 
    {
        int numberOfTickets = 0;
        for (int i = 0; i < _count; i++)
        {
            if (tickets[i].Owner == user)
            {
                Console.WriteLine(tickets[i].PrintCheck());
                numberOfTickets++;
            }
        }
        if (numberOfTickets == 0)
        {
            Console.WriteLine("This user has no  tickets.");
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new TicketEnumerator(tickets);
    }
    
    public void NatSort()
    {
        Array.Sort(tickets, 0, _count);
    }
    
    public void AltSort()
    {
        Array.Sort(tickets, 0, _count, new TicketComparer());
    }
}