﻿namespace FinalProject.Contracts.Responses;

public class MoviesResponse
{
    public IEnumerable<MovieResponse> Items { get; set; } = [];
}
