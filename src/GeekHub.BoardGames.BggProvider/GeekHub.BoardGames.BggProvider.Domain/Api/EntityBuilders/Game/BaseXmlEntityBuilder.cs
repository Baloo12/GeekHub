namespace GeekHub.BoardGames.BggProvider.Domain.Api.EntityBuilders.Game
{
    public abstract class BaseXmlEntityBuilder<T> : IEntityBuilder<T>
        where T : new()
    {
        protected BaseXmlEntityBuilder()
        {
            Entity = new();
        }

        protected T Entity { get; }

        public T Build()
        {
            return Entity;
        }
    }
}
