namespace GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Game
{
    using System.Xml;

    using GeekHub.BoardGames.BggProvider.Domain.Entities;

    public class XmlGameBuilder : BaseXmlEntityBuilder<BoardGame>, IGameBuilder
    {
        private readonly XmlElement _xmlGame;

        public XmlGameBuilder(XmlElement xmlElement)
        {
            _xmlGame = xmlElement;
        }

        public IGameBuilder WithBggId()
        {
            Entity.BggId = ExtractBggId();
            return this;
        }

        public IGameBuilder WithName()
        {
            Entity.Name = ExtractName();
            return this;
        }

        private int ExtractBggId()
        {
            var bggId = _xmlGame.GetAttribute("id");

            return int.TryParse(bggId, out var result)
                ? result
                : -1;
        }

        private string ExtractName()
        {
            var result = string.Empty;
            var nameElements = _xmlGame.GetElementsByTagName("name");
            foreach (var element in nameElements)
            {
                var xmlElement = element as XmlElement;
                var type = xmlElement.GetAttribute("type");
                if (type is "primary")
                {
                    var name = xmlElement.GetAttribute("value");
                    if (name != string.Empty)
                    {
                        result = name;
                        break;
                    }
                }
            }

            return result;
        }

    }
}
