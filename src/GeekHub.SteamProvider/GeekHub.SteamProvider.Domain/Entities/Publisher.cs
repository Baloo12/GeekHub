using System;
using System.ComponentModel.DataAnnotations;

namespace GeekHub.SteamProvider.Domain.Entities
{
    public class Publisher
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}