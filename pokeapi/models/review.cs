namespace pokeapi.models
{
    public class review
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public reviewer Reviewer { get; set; }
        public pokemon pokemon { get; set; }
    }
}
