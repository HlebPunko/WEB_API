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
        //AppContext TODO
        public DbSet<EventInformation> EventInformations { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
						.HasKey(u => u.Id);
			modelBuilder.Entity<User>().Property(u => u.Id)
						.ValueGeneratedOnAdd();
			modelBuilder.Entity<User>().Property(u => u.Login)
						.IsRequired();
			modelBuilder.Entity<User>().Property(u => u.Password)
						.IsRequired();
			modelBuilder.Entity<User>().HasData(new User[] { new User() {Id = 200, Login = "1111", Password = "1111"}});
		}
	}
}