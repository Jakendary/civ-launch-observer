using Newtonsoft.Json;

namespace LaunchObserver.Models
{
    class Launch
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("net")]
        public DateTime? LaunchDate { get; set; }

        [JsonProperty("launch_service_provider.name")]
        public string? LaunchProvider { get; set; }

        [JsonProperty("mission.name")]
        public string? MissionName { get; set; }

        [JsonProperty("mission_description")]
        public string? MissionDescription { get; set; }

        [JsonProperty("pad.name")]
        public string? PadName { get; set; }

        [JsonProperty("rocket.configuration.name")]
        public string? RocketName { get; set; }

        [JsonProperty("image.image_url")]
        public string? Image { get; set; }
    }
}
