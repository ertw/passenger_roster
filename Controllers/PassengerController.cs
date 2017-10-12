// passenger controller - handles routing

// include aspnet for contollers & routing decoration
using Microsoft.AspNetCore.Mvc;
// include Linq to filtering List<>
using System.Linq;

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
        [HttpGet("{id}")]
        public IActionResult GetPassenger(int id)
        {
            var passengerToReturn = PassengersDataStore.Current.Passengers
                .FirstOrDefault(c => c.Id == id);
            return passengerToReturn != null
                ? (IActionResult) Ok(passengerToReturn)
                : NotFound();
        }
    }
}
