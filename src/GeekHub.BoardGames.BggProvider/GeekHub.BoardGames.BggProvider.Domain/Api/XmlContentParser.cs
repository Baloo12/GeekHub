namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.IO;
    using System.Xml;

    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public class XmlContentParser : IContentParser
    {
        public BoardGame ParseGame(string gameContent)
        {
            var xDoc = new XmlDocument();
            xDoc.LoadXml(gameContent);
            var itemElements = xDoc.GetElementsByTagName("item");
            if (itemElements.Count != 1)
            {
                throw new InvalidDataException();
            }
            var gameBuilder = new XmlGameBuilder(itemElements[0] as XmlElement);

            var game = gameBuilder.WithBggId().WithName().Build();

            return game;
        }
    }
}
