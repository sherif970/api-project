using Microsoft.AspNetCore.Identity;

namespace pokeapi.models
{
    public class Applicationuser :IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
    }
}
