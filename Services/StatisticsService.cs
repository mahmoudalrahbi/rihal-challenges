using School.Models;
using School.Repistory.Interfaces;
using School.Services.Interfaces;

namespace School.Services
{
    public class StatisticsService : IStatisticsService
    {

        private readonly IStudentRepository _studentRepository;

        public StatisticsService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<ChartModel>> getStudentsPerClassAsync()
        {

            var studentsPerClass = await _studentRepository.getstudentsPerClassAsync();

            return studentsPerClass;
        }

        public async Task<List<ChartModel>> getStudetnsPerCountry()
        {

            var studentsPerCounties = await _studentRepository.getStudentsPerCountryAsync();

            return studentsPerCounties;
        }
    }
}