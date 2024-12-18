using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartVejrApp;

namespace smartAppApiController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class smartAppApiController : ControllerBase
    {
        private readonly SmartVejrAppRepository _repository; // Læs repository
        public smartAppApiController()
        {
            _repository = new SmartVejrAppRepository(); // init repository
        }

        // GET: api/Weather
        [HttpGet]
        public ActionResult<IEnumerable<Weather>> Get() 
        {
            var weathers = _repository.GetAll(); // get all repository.
            return Ok(weathers);
        }

        // GET api/Weather
        [HttpGet("{id}")]
        [EnableCors("allowAll")]
        public ActionResult<Weather> Get(int id)
        {
            var weather = _repository.GetById(id); // kør getbyid("id")
            if (weather == null) // hvis weather er null
            {
                return NotFound($"Weather med id {id}, ikke fundet."); //fejl
            }
            return Ok(weather); //ok, return.
        }

        // POST api/Weather
        [HttpPost]
        [EnableCors("allowAll")]
        public ActionResult<Weather> Post([FromBody] Weather newWeather)
        {
            if (newWeather == null) // hvis null
            {
                return BadRequest("Weather er null."); // return null.
            }
            var addedWeather = _repository.Add(newWeather); // tilføjet weather.
            return CreatedAtAction(nameof(Get), new { id = addedWeather.Id }, addedWeather); // returnere 201 Status ok
        }

        // PUT api/Weather
        [HttpPut("{id}")]
        [EnableCors("allowAll")]
        public ActionResult<Weather> Put(int id, [FromBody] Weather updatedWeather)
        {
            var existingWeather = _repository.Update(id, updatedWeather); // put id
            if (existingWeather == null) // hvis null
            {
                return NotFound($"Weather med Id {id}, er ikke fundet."); // fejl
            }
            return Ok(existingWeather); //ok, return
        }

        // DELETE api/Weather
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // delete (ikke lavet)
        }
    }
}
