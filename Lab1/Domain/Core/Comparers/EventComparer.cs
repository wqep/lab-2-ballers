using System.Collections;

namespace Lab1.Domain.Core.Comparers;

public class EventComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Event c1 = x as Event;
        Event c2 = y as Event;

        return string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase);
    }
}