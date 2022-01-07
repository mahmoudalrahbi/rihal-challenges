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
            List<ChartModel> list = new List<ChartModel>();

            var studentsBerClass = await _studentRepository.getStudentsBerClassAsync();

            if(studentsBerClass != null)
            {
                foreach(var s in studentsBerClass)
                {
                    Console.WriteLine(s.category_name +" ,"+ s.count);
                    
                }
            }

            return list;
        }

        public async Task<List<ChartModel>> getStudetnsPerCountry()
        {
           List<ChartModel> list = new List<ChartModel>();

            var studentsBerClass = await _studentRepository.getStudentsBerCountryAsync();

            if(studentsBerClass != null)
            {
                foreach(var s in studentsBerClass)
                {
                    Console.WriteLine(s.category_name +" ,"+ s.count);
                    
                }
            }

            return list;
        }
    }
}