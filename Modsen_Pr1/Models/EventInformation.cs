namespace Modsen_Pr1.Models;
public class EventInformation
{
    public int Id { get; set; }
    public string EventName { get; set; } = null!;
    public string EventDescription { get; set; } = null!;
    public string Organizer { get; set; } = null!;
    public DateTime TimeSpending { get; set; }
    public string Location { get; set; } = null!;
    public User User { get; set; } = null!;
    public int UserId { get; set; } = 0;
}