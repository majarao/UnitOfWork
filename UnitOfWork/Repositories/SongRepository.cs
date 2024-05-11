using Microsoft.EntityFrameworkCore;
using UnitOfWork.Abstractions;
using UnitOfWork.Context;
using UnitOfWork.Entities;

namespace UnitOfWork.Repositories;

public class SongRepository(AppDbContext appDbContext) : ISongRepository
{
    private readonly AppDbContext AppDbContext = appDbContext;

    public Song Create(Song entity)
    {
        AppDbContext.Set<Song>().Add(entity);
        return entity;
    }

    public bool Delete(int entityId)
    {
        Song? song = ReadById(entityId);
        if (song is not null)
        {
            AppDbContext.Set<Song>().Remove(song);
            return true;
        }

        return false;
    }

    public IQueryable<Song>? Read() => AppDbContext.Set<Song>();

    public Song? ReadById(int entityId) => Read()?.FirstOrDefault(s => s.SongId == entityId);

    public IQueryable<Song>? ReadByMusicalGenreId(int MusicalGenreId) => Read()?.Where(s => s.MusicalGenreId == MusicalGenreId);

    public Song Update(Song entity)
    {
        AppDbContext.Set<Song>().Update(entity);
        return entity;
    }
}
