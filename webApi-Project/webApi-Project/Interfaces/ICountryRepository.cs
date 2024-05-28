using webApi_Project.Models;

namespace webApi_Project.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountryById(int id);
        Country GetCountryByName(string name);
        bool CountryExists(int id);
    }
}
