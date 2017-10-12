// include controller
using Microsoft.AspNetCore.Mvc;
// include for List<> collection
using System.Collections.Generic;

namespace app
{
    public class PassengerController : Controller
    {
        [HttpGet("api/passengers")]
        public JsonResult GetPassengers()
        {
            return new JsonResult(new List<object>()
                    {
                    new { id=1, name="George" }
                    , new { id=2, name="Newman" }
                    , new { id=3, name="Kramer" }
                    });
        }
    }
}
