using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Abstractions;
using UnitOfWork.Entities;

namespace UnitOfWork.Controllers;

[Route("[controller]")]
[ApiController]
public class SongsController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork UnitOfWork = unitOfWork;

    [HttpPost]
    public ActionResult<Song> Create(Song song)
    {
        song = UnitOfWork.SongRepository.Create(song);
        UnitOfWork.Commit();
        return Ok(song);
    }

    [HttpDelete("songId:int")]
    public ActionResult Delete(int songId)
    {
        Song? song = UnitOfWork.SongRepository.ReadById(songId);
        if (song is null)
            return NoContent();

        if (!UnitOfWork.SongRepository.Delete(songId))
            return BadRequest();

        UnitOfWork.Commit();
        return Ok();
    }

    [HttpGet]
    public ActionResult<IQueryable<Song>> Read()
    {
        IQueryable<Song>? songs = UnitOfWork.SongRepository.Read();
        if (songs!.Any())
            return Ok(songs);

        return NoContent();
    }

    [HttpGet("songId:int")]
    public ActionResult<MusicalGenre> ReadById(int songId)
    {
        Song? song = UnitOfWork.SongRepository.ReadById(songId);
        if (song is null)
            return NoContent();

        return Ok(song);
    }

    [HttpGet("MusicalGenreId:int")]
    public ActionResult<IQueryable<Song>> ReadByMusicalGenreId(int MusicalGenreId)
    {
        IQueryable<Song>? songs = UnitOfWork.SongRepository.ReadByMusicalGenreId(MusicalGenreId);
        if (songs!.Any())
            return Ok(songs);

        return NoContent();
    }

    [HttpPut("songId:int")]
    public ActionResult<bool> Update(int songId, Song song)
    {
        if (song is null)
            return NoContent();

        if (songId != song.SongId)
            return BadRequest();

        song = UnitOfWork.SongRepository.Update(song);
        UnitOfWork.Commit();
        return Ok(song);
    }
}
