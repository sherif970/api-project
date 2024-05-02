using System.Text.Json.Serialization;

namespace pokeapi.models
{
    public class country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<owner> owner { get; set; }
    }
}
