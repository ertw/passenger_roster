using System;
using System.Linq;
using Xunit;
using PassengerRoster.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;


namespace PassengerRoster.UnitTests.Controllers
{
    public class GetPassengerShould
    {
        private readonly DbContextOptions<Entities.PassengerContext> _options;

        public GetPassengerShould()
        {
            var db_user
                = Environment
                .GetEnvironmentVariable("POSTGRES_USER");
            var db_pass
                = Environment
                .GetEnvironmentVariable("POSTGRES_PASSWORD");
            var connectionString
                = $"Host=db;Database=test;Username={db_user};Password={db_pass}";
            var builder
                = new DbContextOptionsBuilder<Entities.PassengerContext>();
            builder
                .UseNpgsql(connectionString);
            _options
                = builder
                .Options;
            using (var context
                    = new Entities.PassengerContext(_options))
                    {
                    context
                        .Database
                        .OpenConnection();
                    }
        }

        private Services.IPassengerRepository _passengerRepository;
        
        [Fact]
        public void CanAddEntity()
        {
            var passenger
                = new Entities
                .Passenger
            {
                  FirstName = "Bill"
                , LastName = "Sal"
                , PhoneNumber = "123-456-7890"
            };

            using (var context
                    = new Entities
                    .PassengerContext(_options))
            {
                context
                    .Passengers
                    .Add(passenger);
                context
                    .SaveChanges();
            }
        }
    }
}
