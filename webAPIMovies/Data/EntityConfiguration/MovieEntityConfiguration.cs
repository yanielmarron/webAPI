using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webAPIMovies.Models;

namespace webAPIMovies.Data.EntityConfiguration;

public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(y => y.Id);
        builder.Property(y => y.Id).ValueGeneratedOnAdd();  
        builder.Property(y => y.Name).HasMaxLength(100).IsRequired();
        builder.Property(y => y.Year).IsRequired();
        builder.Property(y => y.Genre).IsRequired();
        builder.HasMany(y => y.Actors).WithMany(x => x.Movies);
    }
}
