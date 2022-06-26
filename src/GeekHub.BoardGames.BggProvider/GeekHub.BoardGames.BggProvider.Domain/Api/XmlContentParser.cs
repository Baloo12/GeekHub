namespace GeekHub.BoardGames.BggProvider.Domain.Api
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders;
    using GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Interfaces;
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
                var playRecord = builder.WithBggId().WithLocation().WithComment().WithDate().WithGame().Build();
                playRecords.Add(playRecord);
            }

            return playRecords;
        }

        // TODO: Refactor
        public PlayRecordsMetadata ParsePlayRecordsMetadata(string content)
        {
            var metadata = new PlayRecordsMetadata();
            var xDoc = new XmlDocument();
            xDoc.LoadXml(content);

            var playsNodeName = "plays";
            var playsElements = xDoc.GetElementsByTagName(playsNodeName);
            if (playsElements[0] is XmlElement playElement)
            {
                var totalAttributeName = "total";
                var pageAttributeName = "page";
                
                metadata.TotalPlays = int.TryParse(playElement.GetAttribute(totalAttributeName), out var total)
                    ? total
                    : throw new AttributeNotFoundException(totalAttributeName, playsNodeName);
                metadata.PageNumber = int.TryParse(playElement.GetAttribute(pageAttributeName), out var pageNumber)
                    ? pageNumber
                    : throw new AttributeNotFoundException(pageAttributeName, playsNodeName);
            }

            return metadata;
        }
    }

    public class AttributeNotFoundException : Exception
    {
        public AttributeNotFoundException(string attributeName, string nodeName)
            : base($"Attribute '{attributeName}' was not found in node '{nodeName}' during parsing XML.")
        {
        }
    }
}
