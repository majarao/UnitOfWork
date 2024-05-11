using UnitOfWork.Context;

namespace UnitOfWork.Entities;

public class Song : EntityBase
{
    public int SongId { get; set; }
    public int MusicalGenreId { get; set; }
    public MusicalGenre? MusicalGenre { get; set; }
    public string Title { get; set; } = string.Empty;
    public string BandName { get; set; } = string.Empty;
    public string AlbumName { get; set; } = string.Empty;
    public int AlbumYear { get; set; }
    public int DurationInSeconds { get; set; }
}
