using Modsen_Pr1.Models;

namespace Modsen_Pr1;

public class DbInitializer
{
    public static void Initialize(EventInfoContext context)
    {
        if (context.EventInformations.Any())
        {
            return;
        }

        var initializeEventInfo = new EventInformation[]
        {
            new EventInformation
            {
                EventName = "Meeting",
                EventDescription = "Meeting/Pre-screening with Middle .NET Developer",
                Organizer = "You",
                TimeSpending = new DateTime(2022, 06, 21, 12, 30, 00),
                Location = "Office, office number 2"
            },
            new EventInformation
            {
                EventName = "Calling",
                EventDescription = "Calling with superiors",
                Organizer = "Superiors",
                TimeSpending = new DateTime(2022, 06, 21, 17, 00, 00),
                Location = "Google Meet"
            },
            new EventInformation
            {
                EventName = "Report",
                EventDescription = "Team performance report",
                Organizer = "Superiors",
                TimeSpending = new DateTime(2022, 06, 22, 12, 00, 00),
                Location = "Google Meet"
            },
            new EventInformation
            {
                EventName = "Calling",
                EventDescription = "Pre-screening with Junior JS Developer",
                Organizer = "You",
                TimeSpending = new DateTime(2022, 06, 22, 15, 00, 00),
                Location = "Google Meet"
            },
            new EventInformation
            {
                EventName = "Calling",
                EventDescription = "Calling with PM Alex Volosevich (about Middle .NET Developer)",
                Organizer = "Alex Volosevich",
                TimeSpending = new DateTime(2022, 06, 22, 16, 30, 00),
                Location = "Telegram"
            }
        };

        context.AddRange(initializeEventInfo);
        context.SaveChanges();

        if (context.Users.Any())
        {
            return;
        }

        var initializeUsers = new User[]
        {
            new User{Login = "Hleb", Password = "1111"},
            new User{Login = "Elena", Password = "2222"}
        };

        context.AddRange(initializeUsers);
        context.SaveChanges();
    }
}