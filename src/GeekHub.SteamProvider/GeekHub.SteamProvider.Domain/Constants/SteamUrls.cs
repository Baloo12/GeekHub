namespace GeekHub.SteamProvider.Domain.Constants
{
    public static class SteamUrls
    {
        public const string Api = "http://api.steampowered.com/";
        public const string Store = "http://store.steampowered.com/";

        public const string GetAllGames = "ISteamApps/GetAppList/v0002/?format=json/";
        public const string GameDetails = "api/appdetails/?format=json&appids=";
    }
}