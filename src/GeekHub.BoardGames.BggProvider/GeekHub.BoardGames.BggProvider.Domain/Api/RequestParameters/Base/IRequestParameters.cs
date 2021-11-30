namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base
{
    public interface IRequestParameters
    {
        string ItemType { get; }

        string BuildParametersString();
    }
}
