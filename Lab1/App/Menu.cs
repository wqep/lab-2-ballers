using Lab1.Domain.Core;
using Lab1.Domain.Storage;

namespace Lab1.App
{
    class Menu
    {
        public static void DemoMenu()
        {
            UserRepository userRepository = new UserRepository();
            WalletRepository walletRepository = new WalletRepository();
            CheckRepository checkRepository = new CheckRepository();
            TicketRepository ticketRepository = new TicketRepository();
            EventRepository eventRepository = new EventRepository();
            DemoDataFactory demoDataFactory = new DemoDataFactory();

            bool isTrue = true;
            while (isTrue)
            {
                Console.WriteLine($"0 - exit\r\n1 - add user\r\n2 - add wallet\r\n3 - add event\r\n4 - buy ticket\r\n5 - print all users\r\n6 - print all events\r\n7 - return ticket\r\n8 - print check\r\n9 - summary for event\r\n10 - final summary\r\n11 - add funds\r\n12 - print tickets of user");
                string stringInput = Console.ReadLine();
                bool isSuccess = int.TryParse(stringInput, out int input);
                if (isSuccess)
                {
                    if (input == 0)
                    {
                        isTrue = false;
                        Console.WriteLine("You exited the program.");
                        break;
                    }
                    else if (input == 1)
                    {
                        Console.WriteLine("Input number of users: ");
                        string numberOfUsersString = Console.ReadLine();
                        bool userSuccess = int.TryParse(numberOfUsersString, out int numberOfUsers);
                        if (userSuccess && numberOfUsers > 0)
                        {
                            int userCount = userRepository.GetCount();
                            for (int i = userCount; i < numberOfUsers + userCount; i++)
                            {
                                User user = demoDataFactory.UserFactory(i);
                                if (!userRepository.AddUser(user))
                                {
                                    Console.WriteLine("Something went wrong.");
                                    break;
                                }
                            }
                            Console.WriteLine("Operation was successful.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("Input number of wallet: ");
                        string numberOfWalletsString = Console.ReadLine();
                        bool walletSuccess = int.TryParse(numberOfWalletsString, out int numberOfWallets);
                        if (walletSuccess && numberOfWallets > 0)
                        {
                            int walletCount = walletRepository.GetCount();
                            for (int i = walletCount; i < numberOfWallets + walletCount; i++)
                            {
                                User user = userRepository.GetUserById("user" + i);
                                if (user == null)
                                {
                                    Console.WriteLine($"There are not enough users to create {numberOfWallets} wallet(s)");
                                    break;
                                }
                                Wallet wallet = demoDataFactory.WalletFactory(i, user);
                                if (!walletRepository.AddWallet(wallet, user))
                                {
                                    Console.WriteLine("Something went wrong.");
                                    break;
                                }
                            }
                            walletCount = walletRepository.GetCount();
                            Console.WriteLine($"Created {walletCount} wallet(s) successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    else if (input == 3)
                    {
                        Console.WriteLine("Input number of events: ");
                        string numberOfEventsString = Console.ReadLine();
                        bool eventSuccess = int.TryParse(numberOfEventsString, out int numberOfEvents);
                        int eventCount = eventRepository.GetCount();
                        for (int i = eventCount; i < eventCount + numberOfEvents; i++)
                        {
                            DateTime now = DateTime.Now;
                            DateTime newDateTime = new DateTime(now.Year, now.Month, now.Day, 13, 30, 0);
                            Event @event = demoDataFactory.EventFactory(i, newDateTime.AddDays(i));
                            if (!eventRepository.AddEvent(@event))
                            {
                                Console.WriteLine("Something went wrong.");
                                break;
                            }
                        }
                        eventCount = eventRepository.GetCount();
                        Console.WriteLine($"Created {numberOfEvents} event(s) successfully.");
                    }
                    else if (input == 4)
                    {
                        Console.WriteLine("Input user id: ");
                        string inputUserId = Console.ReadLine();
                        if (inputUserId != null)
                        {
                            User user = userRepository.GetUserById(inputUserId);
                            if (user == null)
                            {
                                Console.WriteLine("No such user exists.");
                            }
                            else
                            {
                                Console.WriteLine("Input event id:");
                                string inputEventId = Console.ReadLine();
                                if (inputEventId != null)
                                {
                                    Event @event = eventRepository.GetEventById(inputEventId);
                                    if (@event == null)
                                    {
                                        Console.WriteLine("No event with such id.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input amount of tickets:");
                                        string amountOfTickets = Console.ReadLine();
                                        bool parsedSuccessfully = int.TryParse(amountOfTickets, out int amount);
                                        if (parsedSuccessfully)
                                        {
                                            int boughtSuccessful = 0;
                                            for (int i = 0; i < amount; i++)
                                            {
                                                int count = checkRepository.GetCount();
                                                Ticket ticket = new Ticket("ticket" + count, @event, user, "none", 600);
                                                bool addedSuccessfully = ticketRepository.AddTicket(ticket, user.Wallet);
                                                if (addedSuccessfully)
                                                {
                                                    boughtSuccessful++;
                                                    checkRepository.UpdateList(ticket);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Not enough money");
                                                    break;
                                                }
                                            }
                                            Console.WriteLine($"Bought {boughtSuccessful} ticket(s) successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input.");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    else if (input == 5)
                    {
                        userRepository.PrintAll();
                    }
                    else if (input == 6)
                    {
                        eventRepository.ChangeStatus();
                        eventRepository.PrintAll();
                    }
                    else if (input == 7)
                    {
                        Console.WriteLine("Input ticket id.");
                        string ticketId = Console.ReadLine();
                        if (ticketId != null)
                        {
                            Ticket ticket = ticketRepository.GetTicketById(ticketId);
                            if (ticket != null)
                            {
                                bool soldSuccessfulyy = checkRepository.SellTicket(ticketRepository.tickets, ticket, ticket.Owner.Wallet, ticketRepository._count);
                                if (soldSuccessfulyy)
                                {
                                    Console.WriteLine("Sold successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No such ticket.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid id.");
                        }
                    }
                    else if (input == 8)
                    {
                        Console.WriteLine("Input check or ticket id:");
                        string inputId = Console.ReadLine();
                        if (inputId != null)
                        {
                            Check check = checkRepository.GetCheckById(inputId);
                            if (check == null)
                            {
                                Ticket ticket = ticketRepository.GetTicketById(inputId);
                                if (ticket == null)
                                {
                                    Console.WriteLine("Invalid id.");
                                }
                                else
                                {
                                    checkRepository.PrintCheck(ticket);
                                }
                            }
                            else
                            {
                                Console.WriteLine(check.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    else if (input == 9)
                    {
                        eventRepository.ChangeStatus();
                        Console.WriteLine("Input event id:");
                        string inputEventId = Console.ReadLine();
                        if (inputEventId != null)
                        {
                            Event @event = eventRepository.GetEventById(inputEventId);
                            if (@event != null)
                            {
                                ticketRepository.EventSummary(@event);
                            }
                            else
                            {
                                Console.WriteLine("No such event.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                    }
                    else if (input == 10)
                    {
                        eventRepository.ChangeStatus();
                        eventRepository.SummaryEvents();
                        checkRepository.SaleSummary();
                    }
                    else if (input == 11)
                    {
                        Console.WriteLine("Input owner id:");
                        string ownerId = Console.ReadLine();
                        if (ownerId == null)
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else
                        {
                            User user = userRepository.GetUserById(ownerId);
                            if (user == null || user.Wallet == null)
                            {
                                Console.WriteLine("No such user or user doesn't have a wallet yet.");
                            }
                            else
                            {
                                Console.WriteLine("Input amount: ");
                                string inputAmountString = Console.ReadLine();
                                bool validAmount = int.TryParse(inputAmountString, out int amount);
                                if (validAmount)
                                {
                                    bool successfullOperation = walletRepository.IncreaseBalance(user.Wallet, amount);
                                    Console.WriteLine("Operation was successful.");
                                }
                                else
                                {
                                    Console.WriteLine("Amount must be greater than 0.");
                                }
                            }  
                        }
                    }
                    else if (input == 12)
                    {
                        Console.WriteLine("Input user id:");
                        string userId = Console.ReadLine();
                        if (userId == null)
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else
                        {
                            User user = userRepository.GetUserById(userId);
                            if (user == null)
                            {
                                Console.WriteLine("No such user exists.");
                            }
                            else
                            {
                                ticketRepository.PrintTicketsForUser(user);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The numer must be between 0 and 12.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}
