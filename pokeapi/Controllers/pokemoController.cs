using Microsoft.AspNetCore.Mvc;
using pokeapi.dto;
using pokeapi.models;
using pokeapi.resposatory;

namespace pokeapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class pokemoController : Controller
    {
        private readonly IPokemonresposator repo;
        public pokemoController(IPokemonresposator repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Getallpokemons()
        {
            if(ModelState.IsValid)
            {
                var poke = repo.GetPokemons();
                return Ok(poke);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public IActionResult Getbopebyid([FromRoute]int id)
        {
            if (repo.Pokemonisexist(id) ==false) { return NotFound(); }
            if (ModelState.IsValid)
            {
                pokemon poke = repo.GetPokemonid(id);
                pokemondto vpoke = new pokemondto();
                vpoke.birthdate = poke.Birthdate;
                vpoke.name = poke.Name;
                vpoke.id = poke.Id;
                return Ok(vpoke);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Createnewpokemon([FromBody] pokemondto newpokemon ,int owenrid, int categoryid)
        {

            if (newpokemon == null) { return BadRequest(ModelState); }
            var countr = repo.GetPokemons()
                .Where(p => p.Name.Trim().ToUpper() == newpokemon.name.Trim().ToUpper())
                .FirstOrDefault();
            if (countr != null)
            {
                ModelState.AddModelError("", "the owner exist");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            pokemon newow = new pokemon();
            newow.Id = newpokemon.id;
            newow.Name = newpokemon.name;
            newow.Birthdate = newpokemon.birthdate;
            repo.Createpokemon(newow,owenrid,categoryid);
            return Ok("sucsessed");
        }
        [HttpPut("{id}")]
        public IActionResult Updateowner(int id, pokemondto newpokemon)
        {
            if (newpokemon == null) { return BadRequest(ModelState); }
            if (id != newpokemon.id) { return BadRequest(ModelState); }
            if (!repo.Pokemonisexist(id)) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            pokemon oldpokemon = new pokemon();
            oldpokemon.Id = newpokemon.id;
            oldpokemon.Name = newpokemon.name;
            oldpokemon.Birthdate = newpokemon.birthdate; 
            repo.Updatepokemon(oldpokemon);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletecategory(int id)
        {
            if (!repo.Pokemonisexist(id)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            pokemon poke = repo.GetPokemonid(id);
            repo.Deletepokemon(poke);
            return NoContent();
        }
    }
}
