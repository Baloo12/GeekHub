namespace GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders
{
    using System;
    using System.Xml;

    using GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Interfaces;
    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public class XmlPlayRecordBuilder : BaseXmlEntityBuilder<PlayRecord>, IPlayRecordBuilder
    {
        private readonly XmlElement _xmlElement;

        public XmlPlayRecordBuilder(XmlElement xmlElement)
        {
            _xmlElement = xmlElement;
        }

        public IPlayRecordBuilder WithBggId()
        {
            Entity.BggId = ExtractBggId();
            return this;
        }

        public IPlayRecordBuilder WithComment()
        {
            Entity.Comments = ExtractComments();
            return this;
        }

        public IPlayRecordBuilder WithDate()
        {
            Entity.Date = ExtractDate();
            return this;
        }

        public IPlayRecordBuilder WithGame()
        {
            // TODO: replace with ExtractGame
            Entity.Game = ExtractGameTemp();
            return this;
        }

        public IPlayRecordBuilder WithLocation()
        {
            Entity.Location = ExtractLocation();
            return this;
        }

        private int ExtractBggId()
        {
            var bggId = _xmlElement.GetAttribute("id");

            return int.TryParse(bggId, out var result)
                ? result
                : -1;
        }

        private string ExtractComments()
        {
            var comments = string.Empty;
            var elements = _xmlElement.GetElementsByTagName("comments");
            if (elements is { Count: 1 })
            {
                comments = elements[0]?.InnerText;
            }

            return comments;
        }

        private DateTime? ExtractDate()
        {
            var dateString = _xmlElement.GetAttribute("date");
            return DateTime.TryParse(dateString, out var date)
                ? date
                : null;
        }

        private BoardGame ExtractGame()
        {
            throw new NotImplementedException();
        }

        private BoardGame ExtractGameTemp()
        {
            BoardGame game = null;
            var gameElements = _xmlElement.GetElementsByTagName("item");
            if (gameElements[0] is XmlElement gameElement)
            {
                game = new BoardGame
                    {
                        Name = gameElement.GetAttribute("name"),
                        BggId = int.TryParse(gameElement.GetAttribute("objectid"), out var id)
                            ? id
                            : -1
                    };
            }

            return game;
        }

        private string ExtractLocation()
        {
            var location = _xmlElement.GetAttribute("location");

            return location;
        }
    }
}
