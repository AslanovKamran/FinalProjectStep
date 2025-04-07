using FinalProject.Application.Models;
using FinalProject.Application.Repository.Abstract;
using FinalProject.Application.Services.Abstract;
using FinalProject.Contracts.Requests;
using FluentValidation;
using System.Runtime.CompilerServices;

namespace FinalProject.Application.Services.Concrete;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repos;
    private readonly IValidator<Movie> _validator;

    public MovieService(IMovieRepository repos, IValidator<Movie> validator)
    {
        _repos = repos;
        _validator = validator;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync(GetAllMoviesRequest request)
    {
        var movies = await _repos.GetAllAsync(request);
        return movies;
    }

    public async Task<Movie?> GetByIdAsync(Guid id)
    {
        var movie = await _repos.GetByIdAsync(id);
        if (movie == null) throw new KeyNotFoundException("Movie by provided Id was not found");

        return movie;
    }
    public async Task<bool> CreateAsync(Movie movie, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(movie,cancellationToken);

        var success = await _repos.CreateAsync(movie,cancellationToken);
        return success;
    }

    public async Task<Movie> UpdateAsync(Movie movie)
    {
        await _validator.ValidateAndThrowAsync(movie);
        var exists = await _repos.DoesExist(movie.Id);

        if (!exists)
            throw new KeyNotFoundException("Movie by provided Id was not found");

        await _repos.UpdateAsync(movie);
        return movie;

    }
    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var success = await _repos.DeleteByIdAsync(id);
        return success;
    }
}
