using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Data.DbContexts;
using BlazorMachinePark.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMachinePark.Data.Repositories
{
    public class MachineRepository : IMachineRepository, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public MachineRepository(IDbContextFactory<AppDbContext> dbFactory)
        {
            _appDbContext = dbFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Machine>> GetAllMachinesAsync()
        {
            return await _appDbContext.Machines
                .Include(m => m.MachineType)
                .Include(m => m.City)
                .ThenInclude(m => m.Country)
                .ToListAsync();
        }

        public async Task<Machine> GetMachineByIdAsync(Guid machineId)
        {
            return await _appDbContext.Machines
                .Include(m => m.MachineType)
                .Include(m => m.City)
                .ThenInclude(m => m.Country)
                .FirstOrDefaultAsync(m => m.Id.Equals(machineId));
        }

        public async Task<Machine> AddMachineAsync(Machine machine)
        {
            var addedEntity = await _appDbContext.Machines.AddAsync(machine);
            await _appDbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<Machine> UpdateMachineAsync(Machine machine)
        {
            var foundMachine = await _appDbContext.Machines.FirstOrDefaultAsync(m => m.Id.Equals(machine.Id));

            if (foundMachine != null)
            {
                foundMachine.IsRunning = machine.IsRunning;
                foundMachine.City = machine.City;
                foundMachine.MachineType = machine.MachineType;

                await _appDbContext.SaveChangesAsync();
                return foundMachine;
            }

            return null;
        }

        public async Task DeleteMachineAsync(Guid machineId)
        {
            var foundMachine = await _appDbContext.Machines.FirstOrDefaultAsync(m => m.Id.Equals(machineId));

            if (foundMachine is null) return;

            _appDbContext.Machines.Remove(foundMachine);
            await _appDbContext.SaveChangesAsync();
        }

        public Task<int> CountMachinesAsync()
        {
            return _appDbContext.Machines.CountAsync();
        }
        
        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}