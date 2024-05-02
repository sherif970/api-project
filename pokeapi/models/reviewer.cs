namespace pokeapi.models;

    public class reviewer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<review> review { get; set; }
        

    }

