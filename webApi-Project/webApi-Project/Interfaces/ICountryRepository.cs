using webApi_Project.Models;

namespace webApi_Project.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountryById(int id);
        Country GetCountryByName(string name);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnerByCountry(int countryId);
        bool CountryExists(int id);
    }
}
