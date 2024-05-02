using Microsoft.AspNetCore.Mvc;
using pokeapi.dto;
using pokeapi.models;
using pokeapi.resposatory;

namespace pokeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatageoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CatageoryController(ICategoryRepository repo)
        {
            this._categoryRepository = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var poke = _categoryRepository.Getallcategories();
                return Ok(poke);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!_categoryRepository.Iscategoryexist(id)) { return NotFound(); }
            if (ModelState.IsValid)
            {
                category ceto = _categoryRepository.Getcategory(id);
                categorydto vpoke = new()
                {
                    id = ceto.Id,
                    name = ceto.Name
                };
                return Ok(vpoke);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}/pokemons")]
        public IActionResult GetCategoryPokemos(int id)
        {
            if (_categoryRepository.Iscategoryexist(id) == false) { return NotFound(); }
            if (ModelState.IsValid)
            {
                List<pokemon> pokes = _categoryRepository.Getallpokebcategor(id).ToList();
                pokemondto pokemondto = new pokemondto();
                List<pokemondto> viewpoke = new List<pokemondto>();
                foreach (pokemon i in pokes)
                {
                    pokemondto.birthdate = i.Birthdate;
                    pokemondto.id = i.Id;
                    pokemondto.name = i.Name;
                    viewpoke.Add(pokemondto);
                }

                return Ok(viewpoke);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Createnewcategor(categorydto newcatog)
        {
            if (newcatog == null) { return BadRequest(ModelState); }
            var category = _categoryRepository.Getallcategories()
                .Where(p => p.Name.Trim().ToUpper() == newcatog.name.Trim().ToUpper())
                .FirstOrDefault();
            if (category != null)
            {
                ModelState.AddModelError("", "the category exist");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            category newcategory = new category();
            newcategory.Id = newcatog.id;
            newcategory.Name = newcatog.name;
            _categoryRepository.Createcataegory(newcategory);
            return Ok("sucsessed");
        }

        [HttpPut("{id}")]
        public IActionResult Updatecategor(int id, categorydto newcategory)
        {
            if (newcategory == null) { return BadRequest(ModelState); }
            if (id != newcategory.id) { return BadRequest(ModelState); }
            if (!_categoryRepository.Iscategoryexist(id)) { return NotFound(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            category oldcategory = new category();
            oldcategory.Id = newcategory.id;
            oldcategory.Name = newcategory.name;
            _categoryRepository.Updatecategory(oldcategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletecategory(int id)
        {
            if (!_categoryRepository.Iscategoryexist(id)) return NotFound();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            category newcategory = _categoryRepository.Getcategory(id);
            _categoryRepository.Deletecategory(newcategory);
            return NoContent();
        }
    }
}