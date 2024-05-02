namespace pokeapi.authentication
{
    public class Authmodel
    {
        public bool Isauthanticated { get; set; }
        public string? Message { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? Token { get; set; }
        public DateTime? Experationdate { get; set; }
    }
}
