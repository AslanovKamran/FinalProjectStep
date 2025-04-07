using FinalProject.Application.Services.Abstract;
using FinalProject.Contracts.Requests;
using FinalProject.Api.EndPoints;
using FinalProject.Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Application.Services.Concrete;
using System.Threading;

namespace FinalProject.Api.Controllers;

[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;
    public MoviesController(IMovieService service) => _service = service;

    #region Get All

    [HttpGet]
    [Route(ApiEndPoints.Movies.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllMoviesRequest request, CancellationToken)
    {
        var movies = await _service.GetAllAsync(request);
        var response = movies.MapToResponse();


        return Ok(response);
    }

    #endregion

    #region Get One

    [HttpGet]
    [Route(ApiEndPoints.Movies.GetOne)]
    public async Task<IActionResult> GetOne([FromRoute] Guid id)
    {
        try
        {
            var movie = await _service.GetByIdAsync(id);
            return Ok(movie?.MapToResponse());
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    #endregion

    #region Create

    [HttpPost]
    [Route(ApiEndPoints.Movies.Create)]
    public async Task<IActionResult> Create([FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
    {
        var movie = request.MapToMovie();

        var success = await _service.CreateAsync(movie, cancellationToken);

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
        var result = await _service.UpdateAsync(movie);
        if (result is null) return NotFound();
        var response = movie.MapToResponse();
        return Ok(response);
    }

    #endregion

    #region Delete

    [HttpDelete]
    [Route(ApiEndPoints.Movies.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var success = await _service.DeleteByIdAsync(id);
        return success ? NoContent() : NotFound();
    }

    #endregion

}
