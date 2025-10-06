using LaunchObserver.Models;
using System.Net;

namespace LaunchObserver.Services
{
    class APIService
    {
        const string base_url = "https://lldev.thespacedevs.com/2.3.0/";

        private async Task<Launch> GetNextLaunchAsync()
        {
            string url = $"{base_url}/launches/?limit=1&...";

            HttpClient client = new();

            HttpRequestMessage request = new(HttpMethod.Get, url);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                //something went wrong
            }


        }
    }
}
