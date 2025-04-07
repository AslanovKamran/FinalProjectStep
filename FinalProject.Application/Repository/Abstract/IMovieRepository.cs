using FinalProject.Application.Models;
using FinalProject.Contracts.Requests;

namespace FinalProject.Application.Repository.Abstract;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync(GetAllMoviesRequest request);
    Task<Movie?> GetByIdAsync(Guid id);
    Task<bool> CreateAsync(Movie movie, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Movie movie);
    Task<bool> DeleteByIdAsync(Guid id);
    Task<bool> DoesExist(Guid id);
}

