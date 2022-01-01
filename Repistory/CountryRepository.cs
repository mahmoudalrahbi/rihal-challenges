using School.Models;
using School.Repistory.Interfaces;

namespace School.Repistory
{
    public class CountryRepository : ICountryRepository
    {
         private readonly MvcSchoolContext _context;


         public CountryRepository(MvcSchoolContext context)
        {
            _context = context;
        }

        public void addCountry(Country country)
        {
            _context.Add(country);
           _context.SaveChanges();
        }

        public bool countryExists(int id)
        {
            return _context.Countries.Any(e => e.id == id);
        }

        public void deleteCountry(int id)
        {
             var country = _context.Countries.Find(id);
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        public void editCountry(Country country)
        {
           _context.Update(country);
        _context.SaveChanges();
        }

        public List<Country> getAllClasses()
        {
            return  _context.Countries.ToList();
        }

        public Country getCountry(int id)
        {
            return _context.Countries.Find(id);
        }
    }
}