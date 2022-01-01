using School.Models;
using School.Services.Interfaces;
using School.Repistory.Interfaces;

namespace School.Services
{
    public class CountryService : ICountryService
    {


        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public void addCountry(Country country)
        {
            _countryRepository.addCountry(country);
        }

        public bool countryExists(int id)
        {
            return _countryRepository.countryExists(id);
        }

        public void deleteCountry(int id)
        {
            _countryRepository.deleteCountry(id);
        }

        public void editCountry(Country country)
        {
            _countryRepository.editCountry(country);
        }

        public List<Country> getAllCoiuntries()
        {
            return _countryRepository.getAllCoiuntries();
        }

        public Country getCountry(int id)
        {
            return _countryRepository.getCountry(id);
        }
    }
}