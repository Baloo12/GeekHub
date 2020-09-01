using System;
using System.Collections.Generic;

namespace GamesHub.DataAccess.Contracts.Models
{
    public class Publisher
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}