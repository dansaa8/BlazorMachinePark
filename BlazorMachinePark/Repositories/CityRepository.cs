using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Data;
using BlazorMachinePark.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorMachinePark.Repositories;

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