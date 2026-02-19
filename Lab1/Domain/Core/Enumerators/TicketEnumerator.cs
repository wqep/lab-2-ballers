using System.Collections;

namespace Lab1.Domain.Core.Enumerators;

public class TicketEnumerator : IEnumerator
{
    private Ticket[] _tickets;
    private int _position = -1;

    public TicketEnumerator(Ticket[] tickets)
    {
        _tickets = tickets;
    }
    
    public bool MoveNext()
    {
        _position++;
        return _position < _tickets.Length;
    }

    public void Reset()
    {
        _position = -1;
    }

    public object Current
    {
        get
        {
            return _tickets[_position];
        }
    }
}