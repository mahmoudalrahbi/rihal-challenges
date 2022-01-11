using School.Models;

namespace School.Services.Interfaces
{
    public interface IStatisticsService
    {
         Task<List<ChartModel>> getStudentsPerClassAsync();
         Task<List<ChartModel>> getStudetnsPerCountry();

          int getAverageAge();

    }
}