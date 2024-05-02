using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pokeapi.models;

namespace pokeapi.resposatory
{
    public interface IOwnerresposator
    {
        ICollection<owner> Getallowners();
        owner Getownerbyid(int id);
        ICollection<pokemon> Getpokemonsofowner(int ownerid );
        ICollection<owner> Getownersofpokemon(int pokeid);
        bool Isonerexist(int id);
        bool Createowner(owner newowner);
        bool Updateowner(owner newowner);
        bool Deleteowner(owner newowner);
    }
}
