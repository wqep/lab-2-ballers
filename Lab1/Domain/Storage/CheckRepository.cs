using System.Collections;
using Lab1.Domain.Core;
using Lab1.Domain.Core.Enumerators;

namespace Lab1.Domain.Storage
{
    class CheckRepository : IEnumerable
    {
        Check[] checks = new Check[1000];
        
        private int _count = 0;

        private int sold = 0;
        private int returned = 0;
        private decimal revenue = 0;

        public int GetCount()
        {
            return _count;
        }

        public void UpdateList(Ticket ticket)
        {
            checks[_count] = new Check("check" + _count, ticket, "Purchasing");

            _count++;
            sold++;
            revenue += ticket.Price;
        }
        
        public Check GetCheckByTicket(Ticket ticket)
        {
            for (int i = 0; i < _count; i++)
            {
                if (checks[i].Ticket.Equals(ticket))
                {
                    return checks[i];
                }
            }
            return null;
        }
        public Check GetCheckById(string id)
        {
            for (int i = 0; i < _count; i++)
            {
                if (checks[i].Id.Equals(id))
                {
                    return checks[i];
                }
            }
            return null;
        }

        public bool SellTicket(Ticket[] tickets, Ticket ticket, Wallet wallet, int _countT)
        {
            Check check = GetCheckByTicket(ticket);
            if (!(tickets.Contains(ticket)) || _countT == 0 || check == null)
            {
                return false;
            }
            ticket.Owner = null;
            wallet.Balance += ticket.Price / (decimal)1.25;
            revenue -= ticket.Price / (decimal)1.25;
            checks[_count] = new Check("check" + _count, ticket, "Returning");

            _count++;
            returned++;
            return true;
        }
        
        public void SaleSummary()
        {
            Console.WriteLine($"Sold: {sold}, Returned: {returned}, Total Revenue: {revenue}");
        }
        public void PrintCheck(Ticket ticket)
        {
            Check check = GetCheckByTicket(ticket);
            if (check != null)
            {
                int _checksFound = 0;
                for (int i = 0; i < _count; i++)
                {
                    if (checks[i].Ticket == ticket)
                    {
                        _checksFound++;
                        Console.WriteLine(checks[i].ToString());
                    }
                    if (_checksFound == 2)
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No checks with such ticket.");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new CheckEnumerator(checks);
        }
    }
}
