using UnitOfWork.Abstractions;
using UnitOfWork.Context;

namespace UnitOfWork.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    public AppDbContext AppDbContext = appDbContext;

    private IMusicalGenreRepository? _musicalGenreRepository;
    private ISongRepository? _songRepository;

    public IMusicalGenreRepository MusicalGenreRepository
    {
        get => _musicalGenreRepository ??= new MusicalGenreRepository(AppDbContext);
    }

    public ISongRepository SongRepository
    {
        get => _songRepository ??= new SongRepository(AppDbContext);
    }

    public void Commit() => AppDbContext.SaveChanges();

    public void Dispose() => AppDbContext.Dispose();
}
