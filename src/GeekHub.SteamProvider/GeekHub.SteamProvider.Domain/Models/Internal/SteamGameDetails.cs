using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace GeekHub.SteamProvider.Domain.Models.Internal
{
    public class SteamGameDetails
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public GameDetailsData Data { get; set; }
    }

    public class GameDetailsData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "is_free")]
        public bool IsFree { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "required_age")]
        public int RequiredAge { get; set; }

        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty(PropertyName = "header_image")]
        public string Image { get; set; }

        [JsonPropertyName("publishers")]
        public List<string> Publishers { get; set; }

        [JsonPropertyName("developers")]
        public List<string> Developers { get; set; }

        [JsonPropertyName("platforms")]
        public Dictionary<string, bool> Platforms { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public ReleaseDate ReleaseDate { get; set; }
    }

    public class Genre
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class ReleaseDate
    {
        [JsonProperty(PropertyName = "coming_soon")]
        public bool ComingSoon { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}