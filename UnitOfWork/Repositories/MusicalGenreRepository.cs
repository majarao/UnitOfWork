using Microsoft.EntityFrameworkCore;
using UnitOfWork.Abstractions;
using UnitOfWork.Context;
using UnitOfWork.Entities;

namespace UnitOfWork.Repositories;

public class MusicalGenreRepository(AppDbContext appDbContext) : IMusicalGenreRepository
{
    private readonly AppDbContext AppDbContext = appDbContext;

    public IQueryable<MusicalGenre>? Read() => AppDbContext.Set<MusicalGenre>();

    public MusicalGenre? ReadById(int entityId) => Read()?.FirstOrDefault(g => g.MusicalGenreId == entityId);

    public MusicalGenre? ReadWithSongs(int MusicalGenreId) => Read()?.Include(g => g.Songs).FirstOrDefault(g => g.MusicalGenreId == MusicalGenreId);
}
