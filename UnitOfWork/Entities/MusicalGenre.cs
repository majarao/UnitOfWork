using UnitOfWork.Context;

namespace UnitOfWork.Entities;

public class MusicalGenre : EntityBase
{
    public int MusicalGenreId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Song>? Songs { get; set; }
}
