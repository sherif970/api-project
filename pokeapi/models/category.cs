using System.Text.Json.Serialization;

namespace pokeapi.models
{
    public class category
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        
        public List<pokemon> pokemons { get; set; }
    }
}
