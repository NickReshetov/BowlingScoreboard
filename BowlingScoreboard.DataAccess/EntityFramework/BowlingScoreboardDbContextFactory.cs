using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BowlingScoreboard.DataAccess.EntityFramework
{
public class BowlingScoreboardDbContextFactory : IDesignTimeDbContextFactory<BowlingScoreboardDbContext>
{
    private static string _connectionString;

    public BowlingScoreboardDbContext CreateDbContext()
    {
        return CreateDbContext(null);
    }

    public BowlingScoreboardDbContext CreateDbContext(string[] args)
    {
        if (string.IsNullOrEmpty(_connectionString))
            LoadConnectionString();
        
        var builder = new DbContextOptionsBuilder<BowlingScoreboardDbContext>();

        builder.UseSqlServer(_connectionString);

        return new BowlingScoreboardDbContext(builder.Options);
    }

    private static void LoadConnectionString()
    {
        ConfigurationBuilder builder = new ConfigurationBuilder();

        builder.AddJsonFile("appsettings.json", optional: false);

        IConfigurationRoot configuration = builder.Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(_connectionString))
            throw new Exception("Can't load connection string from appsettings.json");
    }
}
}
