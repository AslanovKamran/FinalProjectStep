using FinalProject.Application.DbConnectionFactory;
using FinalProject.Application.Models;
using FinalProject.Application.Repository.Abstract;
using System.Data;
using Dapper;

namespace FinalProject.Application.Repository.Concrete;

public class MovieRepository : IMovieRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public MovieRepository(IDbConnectionFactory dbConnectionFactory) => _dbConnectionFactory = dbConnectionFactory;

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
        {
            string query = "GetAllMovies";
            var result = await connection.QueryAsync<Movie>(query, commandType: CommandType.StoredProcedure);
            return result;
        }
    }

    public async Task<Movie?> GetByIdAsync(Guid id)
    {
        using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);


            string query = "GetMovieById";
            var result = await connection.QueryFirstOrDefaultAsync<Movie>(query, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }

    public async Task<bool> CreateAsync(Movie movie)
    {
        using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", movie.Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Title", movie.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("YearOfRelease", movie.YearOfRelease, DbType.Int32, ParameterDirection.Input);

            string query = "CreateMovie";
            var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }

    public async Task<bool> UpdateAsync(Movie movie)
    {
        using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", movie.Id, DbType.Guid, ParameterDirection.Input);
            parameters.Add("Title", movie.Title, DbType.String, ParameterDirection.Input);
            parameters.Add("YearOfRelease", movie.YearOfRelease, DbType.Int32, ParameterDirection.Input);
            string query = "UpdateMovie";
            var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
      
        using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            string query = "DeleteMovieById";
            var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }

    public async Task<bool> DoesExist(Guid id) 
    {
        using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Guid, ParameterDirection.Input);
            string query = "DoesExist";
            var result = await connection.ExecuteScalarAsync<int>(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }

}
