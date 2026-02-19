using System.Collections;

namespace Lab1.Domain.Core.Comparers;

public class WalletComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Wallet c1 = (Wallet)x;
        Wallet c2 = (Wallet)y;

        return c1.Balance.CompareTo(c2.Balance);
    }
}