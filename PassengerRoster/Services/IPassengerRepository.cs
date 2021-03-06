using System.Collections.Generic;

namespace PassengerRoster.Services
{
    public interface IPassengerRepository
    {
        IEnumerable<Entities.Passenger> GetPassengers();

        Entities.Passenger GetPassenger(int id);

        void AddPassenger(Entities.Passenger passenger);

        bool Save();
    }
}
