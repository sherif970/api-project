using Microsoft.EntityFrameworkCore;
using pokeapi.models;

namespace pokeapi.resposatory
{
    public class Ownerresposatory : IOwnerresposator
    {
        private readonly context contet;

        public Ownerresposatory(context contet)
        {
            this.contet = contet;
        }

        public bool Createowner(owner newowner)
        {
            contet.Add(newowner);
            contet.SaveChanges();
            return true;
        }

        public bool Deleteowner(owner newowner)
        {
            contet.Remove(newowner);
            contet.SaveChanges();
            return true;
        }

        public ICollection<owner> Getallowners()
        {

            var owners = contet.owners.ToList();
            return owners;
        }

        public owner Getownerbyid(int id)
        {
            var owner = contet.owners.FirstOrDefault(o => o.Id == id);
            return owner;
        }

        public ICollection<owner> Getownersofpokemon(int pokeid)
        {
            var owwners = contet.pokemons.Include(p => p.Owner).FirstOrDefault(p => p.Id == pokeid);
            List<owner> ownerpokemons = owwners.Owner.ToList();
            return ownerpokemons;
        }

        public ICollection<pokemon> Getpokemonsofowner(int ownerid)
        {
            owner pokemons = contet.owners.Include(p => p.pokemons).FirstOrDefault(p => p.Id == ownerid);
            List<pokemon> pokemonsowner = pokemons.pokemons.ToList();
            return pokemonsowner;
        }

        public bool Isonerexist(int id)
        {
            return contet.owners.Any(p => p.Id == id);
        }

        public bool Updateowner(owner newowner)
        {
            contet.Update(newowner);
            contet.SaveChanges();
            return true;
        }
    }
}
