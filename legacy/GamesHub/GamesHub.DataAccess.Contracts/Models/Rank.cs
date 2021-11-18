namespace GamesHub.DataAccess.Contracts.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rank
    {
        [InverseProperty("Rank")]
        public Game Game { get; set; }

        [Key]
        public Guid Id { get; set; }

        public int Overall { get; set; }
    }
}