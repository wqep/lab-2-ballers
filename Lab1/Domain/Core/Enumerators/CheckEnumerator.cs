using System.Collections;

namespace Lab1.Domain.Core.Enumerators;

public class CheckEnumerator : IEnumerator
{
    private Check[] _checks;
    private int _position = -1;

    public CheckEnumerator(Check[] checks)
    {
        _checks = checks;
    }
    
    public bool MoveNext()
    {
        _position++;
        return _position < _checks.Length;
    }

    public void Reset()
    {
        _position = -1;
    }

    public object Current
    {
        get
        {
            return _checks[_position];
        }
    }
}