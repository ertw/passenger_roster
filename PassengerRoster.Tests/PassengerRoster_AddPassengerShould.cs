using System;
using Xunit;
using PassengerRoster.Services;

namespace PassengerRoster.UnitTests.Services
{
    public class AddPassengerShould
    {
        private readonly IPassengerRepository _passengerRepository;
        
        public AddPassengerShould(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        [Fact]
        public void GetAPassengerByID()
        {
            var passenger = _passengerRepository.GetPassenger(1);

            if (passenger == null)
            {
                Assert.False(false, "Passenger should not be null");
            }
        }
    }
}
