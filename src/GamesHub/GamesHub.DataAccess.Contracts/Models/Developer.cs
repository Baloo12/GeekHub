using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesHub.DataAccess.Contracts.Models
{
    public class Developer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(Developer))]
        public ICollection<GameDeveloper> Games { get; set; }
    }
}