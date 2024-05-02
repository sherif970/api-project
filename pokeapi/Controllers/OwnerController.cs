using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokeapi.dto;
using pokeapi.models;
using pokeapi.resposatory;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace pokeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerresposator repo_owner;
        private readonly ICountryresposator repo_country;

        public OwnerController(IOwnerresposator repo_owner,ICountryresposator repo_country)
        {
            this.repo_owner = repo_owner;
            this.repo_country = repo_country;
        }
        [HttpGet]
        public IActionResult Getallowners()
        {
            if (ModelState.IsValid)
            {
                var poke = repo_owner.Getallowners().ToList();
                return Ok(poke);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        public IActionResult Getbopebyid([FromRoute] int id)
        {
            if (!repo_owner.Isonerexist(id)) { return NotFound(); }
            if (ModelState.IsValid)
            {
                owner poke = repo_owner.Getownerbyid(id);
                ownerdto vpoke = new()
                {
                    gym = poke.Gym,
                    name = poke.Name,
                    id = poke.Id
                };
                return Ok(vpoke);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}/pokemons")]
        public IActionResult Getpokemonsofowner(int id)
        {
            if (!repo_owner.Isonerexist(id)) { return NotFound(); }
            if (ModelState.IsValid)
            {
                List<pokemon> poke = repo_owner.Getpokemonsofowner(id).ToList();
                List<pokemondto> reto = new List<pokemondto>();
                foreach (pokemon item in poke)
                {
                    pokemondto vpoke = new pokemondto();
                    vpoke.name=item.Name;
                    vpoke.id=item.Id;
                    vpoke.birthdate = item.Birthdate;
                    reto.Add(vpoke);
                }
                return Ok(reto);    
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Createnewowner([FromBody]ownerdto newowner,[FromQuery]int countryid)
        {

            if (newowner == null) { return BadRequest(ModelState); }
            var testownr = repo_owner.Getallowners()
                .FirstOrDefault(p => string.Equals(p.Name.Trim(), newowner.name.Trim(), StringComparison.OrdinalIgnoreCase));
            if (testownr != null)
            {
                ModelState.AddModelError("", "the owner exist");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            owner newow = new()
            {
                Id = newowner.id,
                Name = newowner.name,
                Gym = newowner.gym
            };
            country count = repo_country.Getcountry(countryid);
            newow.Country = count;
            repo_owner.Createowner(newow);
            return Ok("sucsessed");
        }
        [HttpPut("{id}")]
        
        public IActionResult Updateowner(int id, ownerdto newowner)
        {
            if (newowner == null) { return BadRequest(ModelState); }
            if (id != newowner.id) { return BadRequest(ModelState); }
            if (!repo_owner.Isonerexist(id)) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            //////////////////////////////////////////
            ///
            string test1 = newowner.name.ToUpper();
            var test2 = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToUpper();
            if ( test1 != test2)
            {
                ModelState.AddModelError("", "not acesss");
                return StatusCode(422, ModelState);
            }

            //////////////////////////////////////////
            owner oldowner = new()
            {
                Id = newowner.id,
                Name = newowner.name,
                Gym = newowner.gym
            };
            repo_owner.Updateowner(oldowner);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletecategory(int id)
        {
            if (!repo_owner.Isonerexist(id)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            owner owner = repo_owner.Getownerbyid(id);
            repo_owner.Deleteowner(owner);
            return NoContent();
        }
    }

}
