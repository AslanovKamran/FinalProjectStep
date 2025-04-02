using FinalProject.Application.Models;

namespace FinalProject.Application.Repository.Abstract;

public interface IMovieRepository
{
    Task<Movie?> GetByIdAsync(Guid id);
    Task<IEnumerable<Movie>> GetAllAsync();

    Task<bool> CreateAsync(Movie movie);
    Task<bool> UpdateAsync(Movie movie);
    Task<bool> DeleteByIdAsync(Guid id);
}

