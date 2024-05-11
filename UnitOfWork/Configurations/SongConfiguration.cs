using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitOfWork.Entities;

namespace UnitOfWork.Configurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("Songs");
        builder.HasKey(s => s.SongId);
        builder.Property(s => s.MusicalGenreId).IsRequired();
        builder.Property(s => s.Title).IsRequired().HasMaxLength(50);
        builder.Property(s => s.BandName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.AlbumName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.AlbumYear).IsRequired();
        builder.Property(s => s.DurationInSeconds).IsRequired();
    }
}
