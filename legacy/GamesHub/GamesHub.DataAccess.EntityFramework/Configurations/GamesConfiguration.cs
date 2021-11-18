namespace GamesHub.DataAccess.EntityFramework.Configurations
{
    using GamesHub.DataAccess.Contracts.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GamesConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.HasOne(x => x.Rank).WithOne(x => x.Game);
        }
    }
}