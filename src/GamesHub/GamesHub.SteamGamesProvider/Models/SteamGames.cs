using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GamesHub.SteamGamesProvider.Models
{
    public class SteamGames
    {
        [JsonPropertyName("applist")]
        public AppList AppList { get; set; }
    }

    public class AppList
    {
        [JsonPropertyName("apps")]
        public List<App> Apps { get; set; }
    }

    public class App
    {
        [JsonPropertyName("appid")]
        public int AppId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
