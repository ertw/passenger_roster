using app.Entities;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    public class DummyController : Controller
    {
        private PassengerContext _ctx;

        public DummyController(PassengerContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdb")]

        public IActionResult TestDatabas()
        {
            return Ok();
        }
    }
}
