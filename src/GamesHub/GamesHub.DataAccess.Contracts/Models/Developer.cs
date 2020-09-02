namespace GamesHub.DataAccess.Contracts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Developer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(Developer))]
        public ICollection<GameDeveloper> GameDevelopers { get; set; }
    }
}