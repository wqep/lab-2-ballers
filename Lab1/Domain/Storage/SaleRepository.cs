using Lab1.Domain.Core;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Storage;
>>>>>>> d61e295 (Tests.)

public class SaleRepository
{
    protected Ticket[] tickets = new Ticket[500];
    protected Check[] checks = new Check[1000];

    protected int _countT = 0;
    protected int _countC = 0;

    protected int sold = 0;
    protected int returned = 0;
    protected decimal revenue = 0;

    public int GetCount()
    {
        return _countT;
    }

    public bool AddTicket(Ticket ticket, Wallet wallet)
    {
        if (tickets.Contains(ticket) || _countT == 500 || wallet.Balance < ticket.BasePrice || ticket.eVent.DT < DateTime.Now)
        {
            return false;
        }
        if (ticket.eVent.Status == "Ongoing")
        {
<<<<<<< HEAD
            if (tickets.Contains(ticket) || _countT == 500 || wallet.Balance < ticket.BasePrice || ticket.eVent.DT < DateTime.Now)
            {
                return false;
            }
            if (ticket.eVent.Status == "Ongoing")
            {
                ticket.Price *= (decimal)0.8;
            }
            ticket.Owner = wallet.User;
            tickets[_countT] = ticket;
            wallet.Balance -= ticket.Price;
            checks[_countC] = new Check("check" + _countC, ticket, "Purchasing");

            _countC++;
            _countT++;
            sold++;
            revenue += ticket.Price;

            return true;
=======
            ticket.Price *= (decimal)0.8;
>>>>>>> d61e295 (Tests.)
        }
        ticket.Owner = wallet.uSer;
        tickets[_countT] = ticket;
        wallet.Balance -= ticket.Price;
        checks[_countC] = new Check("check" + _countC, ticket, "Purchasing");

        _countC++;
        _countT++;
        sold++;
        revenue += ticket.Price;

        return true;
    }
    public Ticket GetTicketById(string id)
    {
        for (int i = 0; i < _countT; i++)
        {
            if (id == tickets[i].Id)
            {
                return tickets[i];
            }
        }
        return null;
    }
    public Check GetCheckByTicket(Ticket ticket)
    {
        for (int i = 0; i < _countC; i++)
        {
            if (checks[i].Ticket.Equals(ticket))
            {
                return checks[i];
            }
        }
        return null;
    }
    public Check GetCheckById(string id)
    {
        for (int i = 0; i < _countC; i++)
        {
            if (checks[i].Id.Equals(id))
            {
                return checks[i];
            }
        }
        return null;
    }

    public bool SellTicket(Ticket ticket, Wallet wallet)
    {
        Check check = GetCheckByTicket(ticket);
        if (!(tickets.Contains(ticket)) || _countT == 0 || check == null)
        {
            return false;
        }
        ticket.Owner = null;
        wallet.Balance += ticket.Price / (decimal)1.25;
        revenue -= ticket.Price / (decimal)1.25;
        checks[_countC] = new Check("check" + _countC, ticket, "Returning");

        _countC++;
        returned++;
        return true;
    }
    public void EventSummary(Event @event)
    {
        decimal revenue = 0;
        for (int i = 0; i < _countT; i++)
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
    public void SaleSummary()
    {
        Console.WriteLine($"Sold: {sold}, Returned: {returned}, Total Revenue: {revenue}");
    }
    public void PrintCheck(Ticket ticket)
    {
        Check check = GetCheckByTicket(ticket);
        if (check != null)
        {
            int _checksFound = 0;
            for (int i = 0; i < _countC; i++)
            {
                if (checks[i].Ticket == ticket)
                {
                    _checksFound++;
                    Console.WriteLine(checks[i].ToString());
                }
                if (_checksFound == 2)
                {
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("No checks with such ticket.");
        }
    }
    public void PrintTicketsForUser(User user)
    {
        int numberOfTickets = 0;
        for (int i = 0; i < _countT; i++)
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
}