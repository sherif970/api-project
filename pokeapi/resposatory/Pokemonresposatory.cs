using pokeapi.models;

namespace pokeapi.resposatory
{
    public class Pokemonresposatory : IPokemonresposator
    {
        private readonly context context;

        public Pokemonresposatory(context context)
        {
            this.context = context;
        }

        public pokemon GetPokemonid(int id)
        {
            pokemon pokemon = context.pokemons.SingleOrDefault(p => p.Id == id);
            return pokemon;
        }

        public pokemon GetPokemonbyname(string name)
        {
            pokemon pokemon = context.pokemons.SingleOrDefault(p => p.Name==name);
            return pokemon;
        }

      

        public ICollection<pokemon> GetPokemons()
        {
            return context.pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool Pokemonisexist(int id)
        {
            return context.pokemons.Any(p => p.Id == id);
        }

        public bool Createpokemon(pokemon pokemon ,int owenrid, int categoryid)
        {
           
            owner owners = context.owners.SingleOrDefault(p => p.Id == owenrid);
            category ctegoryk = context.categories.SingleOrDefault(p => p.Id == categoryid);
            ctegoryk.pokemons = new List<pokemon>();
            owners.pokemons = new List<pokemon>();
            context.pokemons.Add(pokemon);
            ctegoryk.pokemons.Add(pokemon);
            owners.pokemons.Add(pokemon);
            context.SaveChanges();
            return true;

            // if i crearting joint table on model creating 
            //var pokemoncategor = new 
            //{
            //    pokemon = pokemon,
            //    Owner = Owner,
            //};
            //var pokemoner = new
            //{
            //    category = ctegory,
            //    pokmon = pokemon,
            //};
        }

        public bool Updatepokemon(pokemon pokemon)
        {
            context.pokemons.Update(pokemon);
            context.SaveChanges();
            return true;
        }

        public bool Deletepokemon(pokemon pokemon)
        {
            context.Remove(pokemon);
            context.SaveChanges();
            return true;
        }
    }
}
