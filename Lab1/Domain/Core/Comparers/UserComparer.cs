using System.Collections;

namespace Lab1.Domain.Core.Comparers;

public class UserComparer : IComparer
{
    public int Compare(object x, object y)
    {
        User c1 = (User)x;
        User c2 = (User)y;
        
        return c1.Wallet.Balance.CompareTo(c2.Wallet.Balance);
    }
}