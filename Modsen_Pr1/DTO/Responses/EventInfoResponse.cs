namespace Modsen_Pr1.DTO.Responses
{
    public class EventInfoResponse
    {
        public int Id { get; set; }
        public string EventName { get; set; } = null!;
        public string EventDescription { get; set; } = null!;
        public string Organizer { get; set; } = null!;
        public DateTime TimeSpending { get; set; }
        public string Location { get; set; } = null!;
    }
}
