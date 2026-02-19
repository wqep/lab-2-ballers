using System.Collections;

namespace Lab1.Domain.Core.Enumerators;

public class WalletEnumerator : IEnumerator
{
    private Wallet[] _wallets;
    private int _position = -1;
    
    public WalletEnumerator(Wallet[] wallets)
    {
        _wallets = wallets;
    }
    
    public bool MoveNext()
    {
        _position++;
        return _position < _wallets.Length;
    }

    public void Reset()
    {
        _position = -1;
    }

    public object Current
    {
        get
        {
            return _wallets[_position];
        }
    }
}