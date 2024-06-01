using webApi_Project.Data;
using webApi_Project.Interfaces;
using webApi_Project.Models;

namespace webApi_Project.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;
        public CountryRepository(DataContext context)
        {
            this.context = context;
        }

        public bool CountryCreate(Country country)
        {
            context.Add(country);
            return Save();
        }

        public bool CountryExists(int id)
        {
            return context.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return context.Countries.OrderBy(c => c.Id).ToList();
        }

        public Country GetCountryById(int id)
        {
            return context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByName(string name)
        {
            return context.Countries.Where(c => c.Name == name).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerByCountry(int countryId)
        {
            return context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
