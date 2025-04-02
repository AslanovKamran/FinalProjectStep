using FinalProject.Application.Models;
using FinalProject.Contracts.Requests;
using FinalProject.Contracts.Responses;

namespace FinalProject.Api.Mapping;

public static class ContractMapping
{
    public static Movie MapToMovie(this CreateMovieRequest request) 
    {
        var movie = new Movie()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
        };
        return movie;
    }

    public static Movie MapToMovie(this UpdateMovieRequest request, Guid id) 
    {
        var movie = new Movie()
        {
            Id = id,
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
        };
        return movie;
    }

    public static MovieResponse MapToResponse(this Movie movie) 
    {
        var response = new MovieResponse()
        {
            Id = movie.Id,
            Title = movie.Title,
            YearOfRelease = movie.YearOfRelease,
        };
        return response;
    }

    public static MoviesResponse MapToResponse(this IEnumerable<Movie> movies) 
    {
        var response = new MoviesResponse()
        {
            Items = movies.Select(movie => movie.MapToResponse())
        };
        return response;
    }
}
