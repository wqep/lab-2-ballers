using System.Collections;

namespace Lab1.Domain.Core.Enumerators;

public class EventEnumerator : IEnumerator
{
    private Event[] _events;
    private int _position = -1;

    public EventEnumerator(Event[] events)
    {
        _events = events;
    }
    
    public bool MoveNext()
    {
        _position++;
        return _position < _events.Length;
    }

    public void Reset()
    {
        _position = -1;
    }

    public object Current
    {
        get
        {
            return _events[_position];
        }
    }
}