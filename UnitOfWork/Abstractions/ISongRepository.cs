using UnitOfWork.Entities;

namespace UnitOfWork.Abstractions;

public interface ISongRepository : IQuerys<Song>, ICommands<Song>
{
    IQueryable<Song>? ReadByMusicalGenreId(int MusicalGenreId);
}
