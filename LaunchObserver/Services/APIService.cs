using LaunchObserver.Models;
using Newtonsoft.Json;
using System.Net;

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
                //something went wrong
            }

            string responseString = await response.Content.ReadAsStringAsync();

            var responseData = JsonConvert.DeserializeObject<Launch.LaunchResponse>(responseString);

            return responseData?.Results?[0] ?? new Launch();
        }
    }
}
