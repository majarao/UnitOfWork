using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Abstractions;
using UnitOfWork.Entities;

namespace UnitOfWork.Controllers;

[Route("[controller]")]
[ApiController]
public class MusicalGenresController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork UnitOfWork = unitOfWork;

    [HttpGet]
    public ActionResult<IQueryable<MusicalGenre>> Read()
    {
        IQueryable<MusicalGenre>? genres = UnitOfWork.MusicalGenreRepository.Read();
        if (genres!.Any())
            return Ok(genres);

        return NoContent();
    }

    [HttpGet("musicalGenreId:int")]
    public ActionResult<MusicalGenre> ReadById(int musicalGenreId)
    {
        MusicalGenre? genre = UnitOfWork.MusicalGenreRepository.ReadById(musicalGenreId);
        if (genre is null)
            return NoContent();

        return Ok(genre);
    }

    [HttpGet("/withsongs/musicalGenreId:int")]
    public ActionResult<MusicalGenre> ReadWithSongs(int musicalGenreId)
    {
        MusicalGenre? genre = UnitOfWork.MusicalGenreRepository.ReadWithSongs(musicalGenreId);
        if (genre is null)
            return NoContent();

        return Ok(genre);
    }
}
