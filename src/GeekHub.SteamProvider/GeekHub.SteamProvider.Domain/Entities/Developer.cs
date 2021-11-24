using System;
using System.ComponentModel.DataAnnotations;

namespace GeekHub.SteamProvider.Domain.Entities
{
    public class Developer
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}