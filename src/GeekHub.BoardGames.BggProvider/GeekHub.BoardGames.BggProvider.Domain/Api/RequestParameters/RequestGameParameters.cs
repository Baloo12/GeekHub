namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters
{
    using System.Collections.Generic;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Constants;
    using GeekHub.BoardGames.BggProvider.Domain.ValueObjects;

    public class RequestGameParameters : IRequestParameters
    {
        public RequestGameParameters()
        {
            PageNumber = 1;
            PageSize = PageSize.From(10);
        }

        [RequestParameter(BggThingParameters.Id)]
        public IEnumerable<int> BggIds { get; set; }

        [RequestParameter(BggThingParameters.Comments)]
        public bool IncludeComments { get; set; }

        [RequestParameter(BggThingParameters.Marketplace)]
        public bool IncludeMarketplace { get; set; }

        [RequestParameter(BggThingParameters.RatingComments)]
        public bool IncludeRatingComments { get; set; }

        [RequestParameter(BggThingParameters.Stats)]
        public bool IncludeStats { get; set; }

        [RequestParameter(BggThingParameters.Versions)]
        public bool IncludeVersions { get; set; }

        [RequestParameter(BggThingParameters.Videos)]
        public bool IncludeVideos { get; set; }

        public string ItemType => BggItemTypes.Thing;

        [RequestParameter(BggThingParameters.Page)]
        public int PageNumber { get; set; }

        [RequestParameter(BggThingParameters.PageSize)]
        public PageSize PageSize { get; set; }

        [RequestParameter(BggThingParameters.Type)]
        public IEnumerable<string> Types { get; set; }
    }
}
