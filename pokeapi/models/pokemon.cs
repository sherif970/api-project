namespace pokeapi.models
{
    public class pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<review> Review { get; set; }
        public List<owner> Owner { get; set; }
        public List<category> category { get; set; }
    }
}
