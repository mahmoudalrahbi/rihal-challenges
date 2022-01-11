using School.Services.Interfaces;

namespace School.Data
{
    public class DataSeeder
    {
        private readonly ISeedDataService _seedDataService;

        public DataSeeder(ISeedDataService seedDataService)
        {
           _seedDataService = seedDataService;
        }


        public void Seed()
        {
            _seedDataService.generateRandomSeedData();
        }
    }
}