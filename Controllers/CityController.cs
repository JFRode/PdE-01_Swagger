using Microsoft.AspNetCore.Mvc;
using PdE_01_BrazilianCitiesAPI.Models;
using PdE_01_BrazilianCitiesAPI.Repository;
using System.Collections.Generic;

namespace PdE_01_BrazilianCitiesAPI.Controllers
{
    [Route("[controller]")]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public IEnumerable<City> GetAll()
        {
            return _cityRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetCity")]
        public IActionResult GetById(long id)
        {
            var city = _cityRepository.Find(id);
            if (city == null)
                return NotFound();

            return new ObjectResult(city);
        }

        [HttpPost]
        public IActionResult Create([FromBody] City city)
        {
            if (city == null)
                return BadRequest();

            _cityRepository.Add(city);

            return CreatedAtRoute("GetCity", new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] City city)
        {
            if (city == null || city.Id != id)
                return BadRequest();

            var _city = _cityRepository.Find(id);

            if (_city == null)
                return NotFound();

            _city.Name = city.Name;
            _city.State = city.State;

            _cityRepository.Update(_city);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var city = _cityRepository.Find(id);

            if (city == null)
                return NotFound();

            _cityRepository.Remove(id);

            return new NoContentResult();
        }
    }
}