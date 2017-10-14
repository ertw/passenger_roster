// passenger controller - handles routing

// include aspnet for contollers & routing decoration
using Microsoft.AspNetCore.Mvc;
// include Linq to filtering List<>
using System.Linq;
// include my models
using app.Models;

namespace app.Controllers
{
	[Route("api/passengers")]
    public class PassengerController : Controller
    {
        [HttpGet()]
        public IActionResult GetPassengers()
        {
            return Ok(PassengersDataStore.Current.Passengers);
        }

        [HttpGet("{id}"
        // name this so we can refer to it later
        , Name = "GetPassenger")]
        public IActionResult GetPassenger(int id)
        {
            var passengerToReturn = PassengersDataStore.Current.Passengers
                // use FirstOrDefault() instead of Where() so I get a null on not found
                .FirstOrDefault(c => c.Id == id);

            return passengerToReturn != null
                // cast because compiler won't do this implicitly
                ? (IActionResult) Ok(passengerToReturn)
                : NotFound();
        }

        [HttpPost()]
        public IActionResult CreatePassenger(
        // deserialize req to PassengerCreationDto
        [FromBody] PassengerCreationDto passenger)
        {
            // if malformed body
            if (passenger == null)
            {
                return BadRequest();
            }

            // check model state for data validation purposes
            if (!ModelState.IsValid)
            {
                // pass in model state, which includes error messages
                return BadRequest(ModelState);
            }

            // find the highest id so we don't have a conflict
            var maxPassengerId = PassengersDataStore.Current.Passengers
                .Max(p => p.Id);

            // create a new passenger
            var newPassenger = new PassengerDto()
            {
                Id = ++maxPassengerId
                , FirstName = passenger.FirstName
                , LastName = passenger.LastName
                , PhoneNumber = passenger.PhoneNumber
            };

            PassengersDataStore.Current.Passengers.Add(newPassenger);

            // return good with created at route
            return CreatedAtRoute("GetPassenger", new
                    { newPassenger.Id }, newPassenger);
        }
    }
}
