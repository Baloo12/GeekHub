namespace GamesHub.Web.Models
{
    using System;
    using System.Collections.Generic;

    public class DeveloperModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<GameModel> Games { get; set; }
    }
}
