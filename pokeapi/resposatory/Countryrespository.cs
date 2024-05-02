using Microsoft.EntityFrameworkCore;
using pokeapi.dto;
using pokeapi.models;

namespace pokeapi.resposatory
{
    public class Countryrespository : ICountryresposator
    {
        private readonly context context;

        public Countryrespository(context context)
        {
            this.context = context;
        }

        public bool Createcountry(country country)
        {
            context.Add(country);
            return Save();
        }

        public bool Deletecountry(country country)
        {
            context.Remove(country);
            context.SaveChanges();
            return true;
        }

        public ICollection<countrydto> Getallcountriesk()
        {
            ICollection<country> categories = context.country.ToList();
            List<countrydto> countrylist = new();
            foreach (var countr in categories)
            {
                countrydto country = new();
                country.id = countr.Id;
                country.name = countr.Name;
                countrylist.Add(country);
            }
            return countrylist;
        }

        public country Getcountry(int id)
        {
            return context.country.SingleOrDefault(p => p.Id == id);
        }

        public country Getcountrybowner(int id)
        {
            return context.owners.Where(p => p.Id == id).Select(s => s.Country).SingleOrDefault();
        }

        public ICollection<owner> Getonersromfromcountry(int id)
        {
            country categpokes = context.country.Include(p => p.owner).FirstOrDefault(e => e.Id == id);
            List<owner> poke = categpokes.owner.ToList();
            return poke;
        }

        public bool Iscountryexist(int id)
        {
            return context.country.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var svd = context.SaveChanges();
            return svd>0?true:false;
        }

        public bool Updatecountry(country country)
        {
            context.Update(country);
            return Save();
        }
    }
}
