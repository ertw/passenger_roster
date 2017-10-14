using Microsoft.EntityFrameworkCore;
namespace app.Entities
{
    public class PassengerContext : DbContext
    {
        public PassengerContext(DbContextOptions<PassengerContext> options)
            : base(options)
        {
            // create the db if it doesn't exist
            Database.EnsureCreated();
        }

        public DbSet<Passenger> Passengers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlite("Data Source=passenger_register.sqlite");
//        }
    }
}
