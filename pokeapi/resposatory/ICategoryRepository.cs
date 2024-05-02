using pokeapi.dto;
using pokeapi.models;

namespace pokeapi.resposatory
{
    public interface ICategoryRepository
    {
        ICollection<category> Getallcategories();
        category Getcategory(int id);
        ICollection<pokemon> Getallpokebcategor(int id);
        bool Iscategoryexist(int id);
        bool Createcataegory(category category);
        bool Updatecategory(category category);
        bool Deletecategory(category category);
        bool Save();

    }
}
