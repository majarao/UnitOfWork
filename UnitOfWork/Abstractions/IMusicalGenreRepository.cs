using UnitOfWork.Entities;

namespace UnitOfWork.Abstractions;

public interface IMusicalGenreRepository : IQuerys<MusicalGenre>
{
    MusicalGenre? ReadWithSongs(int MusicalGenreId);
}
