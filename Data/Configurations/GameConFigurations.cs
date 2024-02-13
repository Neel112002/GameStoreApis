using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Api.Data.Configurations;

public class GameConFigurations : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(game => game.Price)
            .HasPrecision(5, 2);
    }
}
