namespace Modsen_Pr1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<EventInformation> EventInformations { get; set; } = new List<EventInformation>();
    }
}
