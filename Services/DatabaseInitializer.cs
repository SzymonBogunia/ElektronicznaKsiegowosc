using Ksiegowosc.Model;
using Microsoft.EntityFrameworkCore;

namespace Ksiegowosc.Services;

public class DatabaseInitializer
{
    private readonly string _dbPath;

    public DatabaseInitializer()
    {
        _dbPath = Path.Combine(FileSystem.AppDataDirectory, "ksiegowosc.db");
    }

    public void InitializeDatabase()
    {
        using var context = new AppDbContext(
            new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite($"Data Source={_dbPath}")
                .Options);

        
        context.Database.EnsureCreated(); 

        
    }
}