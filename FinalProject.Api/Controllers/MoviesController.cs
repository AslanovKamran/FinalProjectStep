using FinalProject.Application.Repository.Abstract;
using FinalProject.Contracts.Requests;
using FinalProject.Api.EndPoints;
using FinalProject.Api.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers;

[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _repos;
    public MoviesController(IMovieRepository repos) => _repos = repos;

    #region Get All

    [HttpGet]
    [Route(ApiEndPoints.Movies.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _repos.GetAllAsync();
        var response = movies.MapToResponse();


        return Ok(response);
    }

    #endregion

    #region Get One

    [HttpGet]
    [Route(ApiEndPoints.Movies.GetOne)]
    public async Task<IActionResult> GetOne([FromRoute] Guid id)
    {
        var movie = await _repos.GetByIdAsync(id);
        if (movie is null) return NotFound();

        var response = movie.MapToResponse();
        return Ok(response);
    }

    #endregion

    #region Create

    [HttpPost]
    [Route(ApiEndPoints.Movies.Create)]
    public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
    {
        var movie = request.MapToMovie();

        var success = await _repos.CreateAsync(movie);
        if (!success)
            return BadRequest();

        var response = movie.MapToResponse();
        return CreatedAtAction(nameof(GetOne), new { id = response.Id }, response);
    }

    #endregion

    #region Update

    [HttpPut]
    [Route(ApiEndPoints.Movies.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest request)
    {
        var movie = request.MapToMovie(id);
        var success = await _repos.UpdateAsync(movie);
        if (!success) return NotFound();
        var result = movie.MapToResponse();
        return Ok(result);
    }

    #endregion

    #region Delete

    [HttpDelete]
    [Route(ApiEndPoints.Movies.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var success = await _repos.DeleteByIdAsync(id);
        return success ? NoContent() : NotFound();
    }

    #endregion

}
