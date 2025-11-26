using LaunchObserver.Models;
using Newtonsoft.Json;
using System.Net;
using AndroidX.Activity;

namespace LaunchObserver.Services
{
    public class APIService
    {
        const string base_url = "https://lldev.thespacedevs.com/2.3.0/";

        public async Task<Launch> GetNextLaunchAsync()
        {
            string url = $"{base_url}launches/upcoming/?limit=1";

            HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, url);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new Launch();
            }

            string responseString = await response.Content.ReadAsStringAsync();

            var responseData = JsonConvert.DeserializeObject<Launch.LaunchResponse>(responseString);

            return responseData?.Results?[0] ?? new Launch();
        }

        public async Task<List<Launch>> GetUpcomingLaunchesAsync()
        {
            string url = $"{base_url}launches/upcoming/";

            HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, url);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new List<Launch>();
            }

            string responseString = await response.Content.ReadAsStringAsync();

            var responseData = JsonConvert.DeserializeObject<Launch.LaunchResponse>(responseString);

            return responseData?.Results ?? new List<Launch>();
        }

        // TODO: Implement 'previous launches' launch list functionality on Launches page.        
        /*public async Task<List<Launch>> GetPreviousLaunchesAsync()
        {
            string url = $"{base_url}launches/previous/";

            HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, url);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new List<Launch>();
            }

            string responseString = await response.Content.ReadAsStringAsync();

            var responseData = JsonConvert.DeserializeObject<Launch.LaunchResponse>(responseString);

            return responseData?.Results ?? new List<Launch>();
        }*/

        public async Task<Launch> GetLaunchDetailsAsync(string launch_id)
        {
            string url = $"{base_url}launches/{launch_id}/";

            HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, url);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new Launch();
            }

            string responseString = await response.Content.ReadAsStringAsync();

            var launch = JsonConvert.DeserializeObject<Launch>(responseString);

            return launch ?? new Launch();
        }
    }
}
