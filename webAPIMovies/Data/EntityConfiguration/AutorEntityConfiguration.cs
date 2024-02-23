using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webAPIMovies.Models;

namespace webAPIMovies.Data.EntityConfiguration;

public class AutorEntityConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(y => y.Id);
        builder.Property(y => y.Id).ValueGeneratedOnAdd();
        builder.Property(y => y.Name).HasMaxLength(100).IsRequired();
        builder.HasMany(y => y.Movies).WithMany(x => x.Actors);
    }
}
