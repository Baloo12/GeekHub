namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters
{
    using System.Collections.Generic;
    using System.Linq;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Constants;
    using GeekHub.BoardGames.BggProvider.Domain.ValueObjects;

    public class RequestGameParameters : BaseRequestParameters
    {
        public RequestParameter<IEnumerable<int>> BggIds => new(BggThingParameters.Id);

        public RequestParameter<bool> IncludeComments => new(BggThingParameters.Comments);

        public RequestParameter<bool> IncludeMarketplace => new(BggThingParameters.Marketplace);

        public RequestParameter<bool> IncludeRatingComments => new(BggThingParameters.RatingComments);

        public RequestParameter<bool> IncludeStats => new(BggThingParameters.Stats);

        public RequestParameter<bool> IncludeVersions => new(BggThingParameters.Versions);

        public RequestParameter<bool> IncludeVideos => new(BggThingParameters.Versions);

        public override string ItemType => BggItemTypes.Thing;

        public RequestParameter<int> PageNumber => new(BggThingParameters.Page, 1);

        public RequestParameter<PageSize> PageSize => new(BggThingParameters.PageSize, ValueObjects.PageSize.From(10));

        public RequestParameter<IEnumerable<string>> Types => new(BggThingParameters.Type);

        protected override string InternalBuildParameters()
        {
            var parameters = new List<string>
                {
                    BggIds.ToString(),
                    IncludeComments.ToString(),
                    IncludeMarketplace.ToString(),
                    IncludeRatingComments.ToString(),
                    IncludeStats.ToString(),
                    IncludeVersions.ToString(),
                    IncludeVideos.ToString(),
                    PageNumber.ToString(),
                    PageSize.ToString(),
                    Types.ToString()
                };

            return parameters.Any()
                ? string.Join('&', parameters)
                : string.Empty;
        }
    }
}
