using System.Collections;
using Lab1.Domain.Core;
using Lab1.Domain.Core.Comparers;
using Lab1.Domain.Core.Enumerators;

namespace Lab1.Domain.Storage
{
    class UserRepository : IEnumerable

    {
    User[] users = new User[50];
    private int _count = 0;

    public int GetCount()
    {
        return _count;
    }

    public bool AddUser(User user)
    {
        if (users.Contains(user) || _count == 50)
        {
            return false;
        }

        users[_count] = user;
        _count++;
        return true;
    }

    public User GetUserById(string id)
    {
        for (int i = 0; i < _count; i++)
        {
            if (id.Equals(users[i].Id))
            {
                return users[i];
            }
        }

        return null;
    }

    public void PrintAll()
    {
        if (_count == 0)
        {
            Console.WriteLine("Create some first.");
        }
        else
        {
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(users[i].ToString());
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new UserEnumerator(users);
    }
    
    public void NatSort()
    {
        Array.Sort(users, 0, _count);
    }
    
    public void AltSort()
    {
        Array.Sort(users, 0, _count, new UserComparer());
    }
    }
}
