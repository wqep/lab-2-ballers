using System.Collections;

namespace Lab1.Domain.Core.Enumerators;

public class UserEnumerator : IEnumerator
{
    private User[] _users;
    private int _position = -1;
    
    public UserEnumerator(User[] users)
    {
        _users = users;
    }
    
    public bool MoveNext()
    {
        _position++;
        return _position < _users.Length;
    }

    public void Reset()
    {
        _position = -1;
    }

    public object Current
    {
        get
        {
            return _users[_position];
        }
    }
}