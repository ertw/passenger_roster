// in-memory data store of passengers

// include collections for List<>
using System.Collections.Generic;
// include my model
using app.Models;

namespace app
{
    public class PassengersDataStore
    {
        // return a static instance of PassengersDataStore
        public static PassengersDataStore Current { get; }
        = new PassengersDataStore();

        // Public interface for List of passengers
        public List<PassengerDto> Passengers { get; set; }

        // Mock up some passengers
        public PassengersDataStore()
        {
            Passengers = new List<PassengerDto>()
            {
                new PassengerDto()
                {
                    Id = 1
                    , FirstName = "George"
                    , LastName = "Costanza"
                    , PhoneNumber = "555-555-5555"
                }
                , new PassengerDto()
                {
                    Id = 2
                    , FirstName = "Kosmo"
                    , LastName = "Kramer"
                    , PhoneNumber = "555-555-4444"
                }
                , new PassengerDto()
                {
                    Id = 3
                    , FirstName = "Elaine"
                    , LastName = "Benes"
                    , PhoneNumber = "555-555-3333"
                }
            };
        }
    }
}
