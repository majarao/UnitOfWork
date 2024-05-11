using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitOfWork.Entities;

namespace UnitOfWork.Configurations;

public class MusicalGenreConfiguration : IEntityTypeConfiguration<MusicalGenre>
{
    public void Configure(EntityTypeBuilder<MusicalGenre> builder)
    {
        builder.ToTable("MusicalGenres");
        builder.HasKey(g => g.MusicalGenreId);
        builder.Property(g => g.Name).IsRequired().HasMaxLength(50);

        List<MusicalGenre> genres = [];
        genres.Add(new() { MusicalGenreId = 1, Name = "Hard Rock" });
        genres.Add(new() { MusicalGenreId = 2, Name = "Heavy Metal" });
        genres.Add(new() { MusicalGenreId = 3, Name = "Progressive Metal" });
        genres.Add(new() { MusicalGenreId = 4, Name = "Nu Metal" });
        genres.Add(new() { MusicalGenreId = 5, Name = "Pop Rock" });
        builder.HasData(genres);
    }
}