using Microsoft.EntityFrameworkCore;
using pokeapi.dto;
using pokeapi.models;
using System.Reflection.Metadata.Ecma335;

namespace pokeapi.resposatory
{
    public class Categoryresposatory : ICategoryRepository
    {
        private readonly context context;

        public Categoryresposatory(context context)
        {
            this.context = context;
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
               
        }

        public bool Createcataegory(category category)
        {
              context.categories.Add(category);
              return Save();
        }

        public ICollection<category> Getallcategories()
        {
           var categories= context.categories.ToList();
            return categories;
        }

        public ICollection<category> GetAll()
        {
            return Getallcategories();
        }

        public ICollection<pokemon> Getallpokebcategor(int id)
        {
            category categpokes = context.categories.Include(p=>p.pokemons).FirstOrDefault(e=>e.Id==id);
            List<pokemon> poke = categpokes.pokemons.ToList();
            return poke;  
        }

        public category Getcategory(int id)
        {

            var categories = context.categories.SingleOrDefault(p=>p.Id==id);
            return categories ;
        }

        public bool Iscategoryexist(int id)
        {
           return context.categories.Any(p => p.Id == id);
        }

        public bool Updatecategory(category category)
        {
            context.Update(category);
            return Save();
        }

        public bool Deletecategory(category category)
        {
            context.Remove(category);
            context.SaveChanges();
            return true;
        }
    }
}
