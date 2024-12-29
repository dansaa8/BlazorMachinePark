using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Data.DbContexts;
using BlazorMachinePark.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMachinePark.Data.Repositories;

public class CityRepository : ICityRepository, IDisposable
{
    private readonly AppDbContext _appDbContext;

    public CityRepository(IDbContextFactory<AppDbContext> dbFactory)
    {
        _appDbContext = dbFactory.CreateDbContext();
    }

    public async Task<IEnumerable<City>> GetAllCities()
    {
        return await _appDbContext.Cities
            .Include(c => c.Country)
            .ToListAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }

}