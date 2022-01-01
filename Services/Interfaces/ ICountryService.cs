using School.Models;

namespace School.Services.Interfaces
{
    public interface ICountryService
    {
        Country getCountry(int id);
        List<Country> getAllCoiuntries();
        void addCountry(Country country);
        void editCountry(Country country);
        void deleteCountry(int id);

        bool countryExists(int id);
    }
}