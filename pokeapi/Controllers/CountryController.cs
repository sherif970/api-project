using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokeapi.dto;
using pokeapi.models;
using pokeapi.resposatory;

namespace pokeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryresposator repo;

        public CountryController(ICountryresposator repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Getallpokemons()
        {
            if (ModelState.IsValid)
            {
                var poke = repo.Getallcountriesk().ToList();
                return Ok(poke);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}/owners")]
        public IActionResult Getcountryofowner(int id)
        {
            if (ModelState.IsValid)
            {
                country count = repo.Getcountrybowner(id);
                return Ok(count);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Createnewcategor(countrydto newcountry)
        {

            if (newcountry == null) { return BadRequest(ModelState); }
            var countr = repo.Getallcountriesk()
                .FirstOrDefault(p => string.Equals(p.name.Trim(), newcountry.name.Trim(), StringComparison.OrdinalIgnoreCase));
            if (countr != null)
            {
                ModelState.AddModelError("", "the country exist");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            country newcou = new country();
            newcou.Id = newcountry.id;
            newcou.Name = newcountry.name;
            repo.Createcountry(newcou);
            return Ok("sucsessed");
        }
        [HttpPut("{id}")]
        public IActionResult Updatecategor(int id, categorydto newcountry)
        {
            if (newcountry == null) { return BadRequest(ModelState); }
            if (id != newcountry.id) { return BadRequest(ModelState); }
            if (!repo.Iscountryexist(id)) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            country oldcountry = new()
            {
                Id = newcountry.id,
                Name = newcountry.name
            };
            repo.Updatecountry(oldcountry);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletecategory(int id)
        {
            if (!repo.Iscountryexist(id)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            country country = repo.Getcountry(id);
            repo.Deletecountry(country);
            return NoContent();
        }

    }

    
}
