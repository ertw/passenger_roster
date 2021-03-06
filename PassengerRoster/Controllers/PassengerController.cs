// passenger controller - handles routing

// include aspnet for contollers & routing decoration
using Microsoft.AspNetCore.Mvc;
// include Linq to filtering List<>
using System.Linq;
// include my models
using PassengerRoster.Models;
using System.Collections.Generic;

namespace PassengerRoster.Controllers
{
	[Route("api/passengers")]
    public class PassengerController : Controller
    {

        private Services.IPassengerRepository _passengerRepository;

        // inject repository
        public PassengerController(Services.IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        [HttpGet()]
        public IActionResult GetPassengers()
        {
            var passengerEntities = _passengerRepository.GetPassengers();

            var results = AutoMapper.Mapper.Map<IEnumerable<PassengerDto>>(passengerEntities);

            return Ok(results);
        }

        [HttpGet("{id}"
        // name this so we can refer to it later
        , Name = "GetPassenger")]
        public IActionResult GetPassenger(int id)
        {
            var passenger = _passengerRepository.GetPassenger(id);

            if (passenger == null)
            {
                return NotFound();
            }

            var result = AutoMapper.Mapper.Map<PassengerDto>(passenger);
            
            return Ok(result);
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

            var newPassenger = AutoMapper.Mapper.Map<Entities.Passenger>(passenger);

            _passengerRepository.AddPassenger(newPassenger);

            _passengerRepository.Save();

            // return good with created at route
            return CreatedAtRoute("GetPassenger", new
                    { newPassenger.Id }, newPassenger);
        }
    }
}
