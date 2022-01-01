using School.Models;

namespace School.Repistory.Interfaces
{
    public interface ICountryRepository
    {
        Country getCountry(int id);
        List<Country> getAllClasses();
        void addCountry(Country country);
        void editCountry(Country country);
        void deleteCountry(int id);

        bool countryExists(int id);
        
    }
}