﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GeekHub.SteamProvider.Domain.Entities
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}