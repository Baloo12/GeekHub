namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base
{
    public interface IRequestParameterConstructor
    {
        string Construct<T>(string key, T value);
    }
}
