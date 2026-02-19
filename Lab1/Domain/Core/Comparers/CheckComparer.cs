using System.Collections;

namespace Lab1.Domain.Core.Comparers;

public class CheckComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Check c1 = x as Check;
        Check c2 = y as Check;

        return string.Compare(c1.Id, c2.Id, StringComparison.OrdinalIgnoreCase);
    }
}