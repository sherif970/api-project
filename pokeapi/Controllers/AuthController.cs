using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokeapi.authentication;

namespace pokeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Iauthservies authservies;

        public AuthController(Iauthservies authservies)
        {
            this.authservies = authservies;
        }
        [HttpPost ("adminregister")]
        public async Task<IActionResult> Registeradmin( [FromBody] Registermodel adminuser)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var result = await authservies.Registeradmin(adminuser);
            if (!result.Isauthanticated) { return Ok(result.Message); }
            return Ok(result);
        }
        [HttpPost("ownerregister")]
        public async Task<IActionResult> Registerowner([FromBody] Registermodel adminuser)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var result = await authservies.Registerowner(adminuser);
            if (!result.Isauthanticated) { return Ok(result.Message); }
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Loginadmin([FromBody] loginmodel adminuser)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var result = await authservies.Login(adminuser);
            if (!result.Isauthanticated) { return Ok(result.Message); }
            return Ok(result);
        }
    }
}
