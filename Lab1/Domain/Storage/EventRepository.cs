using Lab1.Domain.Core;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Storage;
>>>>>>> d61e295 (Tests.)

public class EventRepository
{
    protected Event[] events = new Event[50];
    protected int _count;

    public int GetCount()
    {
        return _count;
    }

    public bool AddEvent(Event evenT)
    {
        if (events.Contains(evenT) || _count == 50)
        {
            return false;
        }
        events[_count] = evenT;
        _count++;
        return true;
    }
    public void ChangeStatus() // for automatic change of event status 
    {
        for (int i = 0; i < _count; i++)
        {
            if (events[i].DT < DateTime.Now)
            {
                events[i].Status = "Finished";
            }
            else if (events[i].DT == DateTime.Now)
            {
                events[i].Status = "Ongoing";
            }
        }
    }
    public void SummaryEvents()
    {
        int planned = 0;
        int ongoing = 0;
        int finished = 0;
        for (int i = 0; i < _count; i++)
        {
            if (events[i].Status == "Finished")
            {
                finished++;
            }
            else if (events[i].Status == "Ongoing")
            {
                ongoing++;
            }
            else
            {
                planned++;
            }
        }
        Console.WriteLine($"Events:\r\nPlanned: {planned}, Ongoing: {ongoing}, Finished: {finished}");
    }

    public Event GetEventById(string id)
    {
        for (int i = 0; i < _count; i++)
        {
            if (id == events[i].Id)
            {
                return events[i];
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
                Console.WriteLine(events[i].ToString());
            }
        }
    }
}