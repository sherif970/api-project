using pokeapi.models;

namespace pokeapi.resposatory
{
    public interface IPokemonresposator
    {
        ICollection<pokemon> GetPokemons ();
        pokemon GetPokemonid(int id);
        pokemon GetPokemonbyname(string name);
        bool Pokemonisexist (int id);
        bool Createpokemon (pokemon pokemon, int owenrid, int categoryid);
        bool Updatepokemon(pokemon pokemon);
        bool Deletepokemon(pokemon pokemon);
    }
}
