using System.Collections;

namespace Lab1.Domain.Core.Comparers;

public class TicketComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Ticket c1 = x as Ticket;
        Ticket c2 = y as Ticket;

        return c1.Price.CompareTo(c2.Price);
    }
}