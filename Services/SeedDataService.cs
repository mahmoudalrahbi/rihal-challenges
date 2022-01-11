using School.Models;
using School.Services.Interfaces;
using School.Repistory.Interfaces;
using Faker;

namespace School.Services
{
    public class SeedDataService : ISeedDataService
    {
        private readonly IClassService _classService;
        private readonly ICountryService _countryService;
        private readonly IStudentService _studentService;


        public SeedDataService(IClassService classService, ICountryService countryService, IStudentService studentService)
        {
            _classService = classService;
            _countryService = countryService;
            _studentService = studentService;
        }

        public void generateRandomSeedData()
        {
            if (!_classService.getAllClasses().Any())
            {
                for (int i = 0; i < 100; i++)
                {
                    Class classData = new Class { class_name = string.Join(" ", Faker.Lorem.Words(1)) };
                    School.Models.Country countiryData = new School.Models.Country { name = Faker.Country.Name() };
                    _classService.addClass(classData);
                    _countryService.addCountry(countiryData);

                    Student student = new Student { name =string.Join(Faker.Name.First(), Faker.Name.Last()), date_of_birth = RandomDay(), Classes = classData, Countries = countiryData };


                    _studentService.addStudent(student);

                }

            }

        }


        private Random gen = new Random();
        private static DateTime start = new DateTime(1900, 1, 1);
        private int range = (DateTime.Today - start).Days;
        DateTime RandomDay()
        {
            return start.AddDays(gen.Next(range));
        }
    }
}