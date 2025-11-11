using LaunchObserver.Services;
using LaunchObserver.Models;

namespace LaunchObserver.Controllers
{
    public class LaunchController
    {
        private readonly APIService _apiService;

        public LaunchController(APIService apiService)
        {
            _apiService = apiService;
        }

        public Task<Launch> GetNextLaunchAsync()
        {
            return _apiService.GetNextLaunchAsync();
        }

        public Task<List<Launch>> GetUpcomingLaunchesAsync()
        {
            return _apiService.GetUpcomingLaunchesAsync();
        }

        public Task<Launch> GetLaunchDetailsAsync(string launch_id)
        {
            return _apiService.GetLaunchDetailsAsync(launch_id);
        }
    }
}
