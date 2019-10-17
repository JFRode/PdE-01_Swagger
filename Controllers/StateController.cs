using Microsoft.AspNetCore.Mvc;
using PdE_01_BrazilianCitiesAPI.Models;
using PdE_01_BrazilianCitiesAPI.Repository;
using System.Collections.Generic;

namespace PdE_01_BrazilianCitiesAPI.Controllers
{
    [Route("[controller]")]
    public class StateController : Controller
    {
        private readonly IStateRepository _stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet]
        public IEnumerable<State> GetAll()
        {
            return _stateRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetState")]
        public IActionResult GetById(long id)
        {
            var state = _stateRepository.Find(id);

            if (state == null)
                return NotFound();

            return new ObjectResult(state);
        }

        [HttpPost]
        public IActionResult Create([FromBody] State state)
        {
            if (state == null)
                return BadRequest();

            _stateRepository.Add(state);

            return CreatedAtRoute("GetState", new { id = state.Id }, state);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] State state)
        {
            if (state == null || state.Id != id)
                return BadRequest();

            var _state = _stateRepository.Find(id);

            if (_state == null)
                return NotFound();

            _state.Name = state.Name;
            _state.Abbreviation = state.Abbreviation;

            _stateRepository.Update(_state);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var state = _stateRepository.Find(id);

            if (state == null)
                return NotFound();

            _stateRepository.Remove(id);

            return new NoContentResult();
        }
    }
}