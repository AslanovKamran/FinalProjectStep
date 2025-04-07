﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace FinalProject.Application.DbConnectionFactory;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
}

public class MsSqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    public MsSqlConnectionFactory(string connectionString) => _connectionString = connectionString;

    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken = default);
        return connection;
    }
}


