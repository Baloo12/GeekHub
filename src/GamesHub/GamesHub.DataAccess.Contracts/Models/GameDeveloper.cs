using System;
using System.Collections.Generic;
using System.Text;

namespace GamesHub.DataAccess.Contracts.Models
{
    public class GameDeveloper
    {
        public Guid Id { get; set; }

        public Game Game { get; set; }

        public Guid GameId { get; set; }

        public Developer Developer { get; set; }

        public Guid DeveloperId { get; set; }
    }
}
