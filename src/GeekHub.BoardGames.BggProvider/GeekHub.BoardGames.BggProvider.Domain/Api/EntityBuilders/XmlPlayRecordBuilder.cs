namespace GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders
{
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

        private string ExtractLocation()
        {
            var location = _xmlElement.GetAttribute("location");

            return location;
        }
    }
}
