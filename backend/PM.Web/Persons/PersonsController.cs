using Microsoft.AspNetCore.Mvc;
using PM.Web.Constants;
using PM.Web.Persons.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Web.Persons
{
    [Route(ApiConstants.ApiRoute)]
    public class PersonsController : ControllerBase
    {
        private readonly EditPersonService _editPersonsService;
        private readonly PersonsPriovider _personsPriovider;

        public PersonsController(EditPersonService editPersonService, PersonsPriovider personPriovider)
        {
            _editPersonsService = editPersonService;
            _personsPriovider = personPriovider;
        }

        [HttpGet]
        public IActionResult GetWithPage([FromQuery(Name = "page")] int page)
        {
            PersonWithPaging persons = _personsPriovider.GetWithPage(page);

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Person person = await _personsPriovider.GetOne(id);

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonVm personVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = await _editPersonsService.Create(personVm);

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PersonVm personVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (personVm.Id == null)
            {
                return BadRequest();
            }

            await _editPersonsService.Edit(personVm);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _editPersonsService.Delete(id);

            return Ok();
        }

        [HttpGet("numbers")]
        public IActionResult Get()
         {
            List<string> personNumbers = _personsPriovider.GetPersonNumbers();
            
            return Ok(personNumbers);
        }
        
    }
}
