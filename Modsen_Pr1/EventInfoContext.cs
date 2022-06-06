using Microsoft.EntityFrameworkCore;
using Modsen_Pr1.Models;

namespace Modsen_Pr1
{
    public class EventInfoContext : DbContext
    {
        public EventInfoContext(DbContextOptions<EventInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<EventInformation> EventInformations { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}