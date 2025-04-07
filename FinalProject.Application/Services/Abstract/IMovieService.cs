using FinalProject.Application.Models;
using FinalProject.Contracts.Requests;

namespace FinalProject.Application.Services.Abstract;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllAsync(GetAllMoviesRequest request);
    Task<Movie?> GetByIdAsync(Guid id);
    Task<bool> CreateAsync(Movie movie, CancellationToken cancellationToken);
    Task<Movie> UpdateAsync(Movie movie);
    Task<bool> DeleteByIdAsync(Guid id);
}
