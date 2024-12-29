using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Data.DbContexts;
using BlazorMachinePark.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMachinePark.Data.Repositories;

public class MachineTypeRepository : IMachineTypeRepository, IDisposable
{
    private readonly AppDbContext _appDbContext;

    public MachineTypeRepository(IDbContextFactory<AppDbContext> dbFactory)
    {
        _appDbContext = dbFactory.CreateDbContext();
    }

    public async Task<IEnumerable<MachineType>> GetAllMachineTypes()
    {
        return await _appDbContext.MachineTypes.ToListAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}