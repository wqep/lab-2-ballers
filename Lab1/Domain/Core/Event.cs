using Lab1.Domain.Core.Interfaces;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Core;
>>>>>>> d61e295 (Tests.)

public class Event : IIdenifiable
{
    public string Id { get; }
    public string Name { get; }
    public string Status { get; set; } = "Planned";
    public DateTime DT { get; }
    public Event(string id, string name, DateTime dT)
    {
        Id = id;
        Name = name;
        DT = dT;
    }
    public override string ToString()
    {
        return $"Id: {Id} Name: {Name} Status: {Status} Scheduled: {DT}\r\n";
    }
}