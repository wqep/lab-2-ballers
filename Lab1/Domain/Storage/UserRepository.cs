using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Domain.Core;
using System.Threading.Tasks;

namespace Lab1.Domain.Storage
{
    class UserRepository
    {
        User[] users = new User[50];
        public UserRepository() { }

        private int _count = 0;

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
    }
}
