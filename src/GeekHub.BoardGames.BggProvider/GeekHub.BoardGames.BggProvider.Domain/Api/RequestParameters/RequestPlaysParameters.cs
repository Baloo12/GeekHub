namespace GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters
{
    using System;

    using GeekHub.BoardGames.BggProvider.Domain.Api.RequestParameters.Base;
    using GeekHub.BoardGames.BggProvider.Domain.Constants;

    public class RequestPlaysParameters : IRequestParameters
    {
       // [RequestParameter(BggPlaysParameters.From)]
        //public DateTime From { get; set; }

        [RequestParameter(BggPlaysParameters.Id)]
        public int Id { get; set; }

        public string ItemType => BggItemTypes.Plays;

        [RequestParameter(BggPlaysParameters.Page)]
        public int Page { get; set; }

        [RequestParameter(BggPlaysParameters.Subtype)]
        public string Subtype { get; set; }

       // [RequestParameter(BggPlaysParameters.To)]
       // public DateTime To { get; set; }

        [RequestParameter(BggPlaysParameters.Type)]
        public string Type { get; set; }

        [RequestParameter(BggPlaysParameters.UserName)]
        public string UserName { get; set; }
    }
}
