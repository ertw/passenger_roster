using System.Collections.Generic;
using System.Linq;

namespace PassengerRoster.Services
{

    public class PassengerRepository : IPassengerRepository
    {
        private Entities.PassengerContext _context;

        public bool PassengerExists(int id)
        {
            return _context
                .Passengers
                .Any(p => p.Id == id);
        }

        public PassengerRepository(Entities.PassengerContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<Entities.Passenger> GetPassengers()
        {
            return _context
                .Passengers
                .OrderBy(p => p.FirstName)
                .ToList();
        }

        public Entities.Passenger GetPassenger(int id)
        {
            return _context
                .Passengers
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public void AddPassenger(Entities.Passenger passenger)
        {
            _context.Passengers.Add(passenger);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
