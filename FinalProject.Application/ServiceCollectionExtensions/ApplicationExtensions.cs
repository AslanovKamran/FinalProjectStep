using FinalProject.Application.DbConnectionFactory;
using FinalProject.Application.Repository.Abstract;
using FinalProject.Application.Repository.Concrete;
using Microsoft.Extensions.DependencyInjection;


namespace FinalProject.Application.ServiceCollectionExtensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IMovieRepository, MovieRepository>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString) 
    {
        services.AddScoped<IDbConnectionFactory, MsSqlConnectionFactory>(provider => new MsSqlConnectionFactory(connectionString));
        return services;
    }
}
