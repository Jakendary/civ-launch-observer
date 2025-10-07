using Newtonsoft.Json;

namespace LaunchObserver.Models
{
    public class Launch
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("net")]
        public DateTime? LaunchDate { get; set; }

        [JsonProperty("status")]
        public LaunchStatus? Status { get; set; }

        [JsonProperty("launch_service_provider")]
        public LaunchProvider? Provider { get; set; }

        [JsonProperty("mission")]
        public LaunchMission? Mission { get; set; }

        [JsonProperty("pad")]
        public LaunchPad? Pad { get; set; }

        [JsonProperty("image")]
        public LaunchImage? Image { get; set; }

        public class LaunchResponse
        {
            [JsonProperty("results")]
            public List<Launch>? Results { get; set; }
        }

        public class LaunchStatus
        {
            [JsonProperty("abbrev")]
            public string? Short { get; set; }
        }

        public class LaunchProvider
        {
            [JsonProperty("name")]
            public string? Name { get; set; }
        }

        public class LaunchPad
        {
            [JsonProperty("name")]
            public string? Name { get; set; }
        }

        public class LaunchMission
        {
            [JsonProperty("name")]
            public string? Name { get; set; }

            [JsonProperty("description")]
            public string? Description { get; set; }
        }

        public class LaunchImage
        {
            [JsonProperty("image_url")]
            public string? ImageUrl { get; set; }
        }
    }
}
