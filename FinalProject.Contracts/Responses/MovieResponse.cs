using System.ComponentModel;

namespace FinalProject.Contracts.Responses;

public class MovieResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; } //Avatar + 20
    public required int YearOfRelease { get; init; } //2012
}
