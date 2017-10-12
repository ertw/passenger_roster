// passenger controller - handles routing

// include controller
using Microsoft.AspNetCore.Mvc;
//// include for List<> collection
//using System.Collections.Generic;

namespace app
{
	[Route("api/passengers")]
    public class PassengerController : Controller
    {
        [HttpGet()]
        public IActionResult GetPassengers()
        {
            return new JsonResult(PassengersDataStore.Current.Passengers);
//            return new JsonResult(new List<object>()
//                    {
//                    new { id=1, name="George" }
//                    , new { id=2, name="Newman" }
//                    , new { id=3, name="Kramer" }
//                    });
        }
//	[HttpGet("api/Passengers/{id}")]
//	public JsonResult GetCity()
//	{
//	}
    }
}
