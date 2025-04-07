using FinalProject.Application.DbConnectionFactory;
using FinalProject.Application.Repository.Abstract;
using FinalProject.Application.Repository.Concrete;
using FinalProject.Application.Services.Abstract;
using FinalProject.Application.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using FinalProject.Application.Markers;
using FluentValidation;


namespace FinalProject.Application.ServiceCollectionExtensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IMovieService, MovieService>();

        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        return services;
    }
    

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString) 
    {
        services.AddScoped<IDbConnectionFactory, MsSqlConnectionFactory>(provider => new MsSqlConnectionFactory(connectionString));
        return services;
    }
}
