namespace GeekHub.BoardGames.BggProvider.Domain
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml;

    using GeekHub.BoardGames.BggProvider.Domain.Constants;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public class BggXmlApiClient : IBggApiClient
    {
        private readonly HttpClient _httpClient;

        public BggXmlApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BoardGame> GetGameAsync(int bggId)
        {
            var url = $"{BggUrls.XmlApi}thing?id={bggId}&stats=1";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var game = ParseGame(content);
            game.BggId = bggId;

            return game;
        }

        private BoardGame ParseGame(string xmlContent)
        {
            var game = new BoardGame();
            var xDoc = new XmlDocument();
            xDoc.LoadXml(xmlContent);
            var itemElements = xDoc.GetElementsByTagName("item");
            if (itemElements.Count != 1)
            {
                throw new InvalidDataException();
            }
            var gameBuilder = new XmlGameBuilder(itemElements[0] as XmlElement);

            game = gameBuilder.WithBggId().WithName().Build();

            return game;
        }
    }
}
