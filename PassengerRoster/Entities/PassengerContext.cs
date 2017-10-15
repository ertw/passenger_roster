using Microsoft.EntityFrameworkCore;
namespace PassengerRoster.Entities
{
    public class PassengerContext : DbContext
    {
        public PassengerContext(DbContextOptions<PassengerContext> options)
            : base(options)
        {
            // run migrations
            Database.Migrate();
        }

        public DbSet<Passenger> Passengers { get; set; }
    }
}
