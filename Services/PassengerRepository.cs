using System.Collections.Generic;
using System.Linq;

namespace app.Services
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
    }
}
