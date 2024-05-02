using pokeapi.dto;
using pokeapi.models;

namespace pokeapi.resposatory
{
    public interface ICountryresposator
    {
       
        ICollection<countrydto>  Getallcountriesk();
        country Getcountrybowner(int id);
        country Getcountry(int id);
        ICollection<owner> Getonersromfromcountry(int id);
        bool Iscountryexist(int id);
        bool Createcountry(country country);
        bool Updatecountry(country country);
        bool Deletecountry(country country);
        bool Save();
    }
}
