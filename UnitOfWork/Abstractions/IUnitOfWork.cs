namespace UnitOfWork.Abstractions;

public interface IUnitOfWork
{
    IMusicalGenreRepository MusicalGenreRepository { get; }
    ISongRepository SongRepository { get; }
    void Commit();
}
