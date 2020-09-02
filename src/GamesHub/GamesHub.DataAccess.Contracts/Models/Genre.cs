﻿namespace GamesHub.DataAccess.Contracts.Models
{
    using System;
    using System.Collections.Generic;

    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}