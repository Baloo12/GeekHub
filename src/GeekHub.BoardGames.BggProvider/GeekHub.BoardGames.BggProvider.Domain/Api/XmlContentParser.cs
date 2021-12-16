namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Game;
    using GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.PlayRecord;
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

        public IEnumerable<PlayRecord> ParsePlayRecords(string content)
        {
            var xDoc = new XmlDocument();
            xDoc.LoadXml(content);
            var itemElements = xDoc.GetElementsByTagName("play");
            var playRecords = new List<PlayRecord>();
            foreach (var itemElement in itemElements)
            {
                IPlayRecordBuilder builder = new XmlPlayRecordBuilder(itemElement as XmlElement);
                var playRecord = builder.WithBggId().WithLocation().Build();
                playRecords.Add(playRecord);
            }

            return playRecords;
        }
    }
}
