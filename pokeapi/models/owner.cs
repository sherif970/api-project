namespace pokeapi.models
{
    public class owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }
        public country Country { get; set; }
        public List<pokemon> pokemons { get; set; }

    }
}
