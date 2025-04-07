using FinalProject.Application.Models;

namespace FinalProject.Application.Services.Abstract;

public interface IMovieService
{
    Task<Movie?> GetByIdAsync(Guid id);
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<bool> CreateAsync(Movie movie);
    Task<Movie> UpdateAsync(Movie movie);
    Task<bool> DeleteByIdAsync(Guid id);
}
