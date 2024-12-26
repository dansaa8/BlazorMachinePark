using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Data;
using BlazorMachinePark.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorMachinePark.Repositories
{
    public class MachineRepository : IMachineRepository, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public MachineRepository(IDbContextFactory<AppDbContext> dbFactory)
        {
            _appDbContext = dbFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Machine>> GetAllMachines()
        {
            return await _appDbContext.Machines
                .Include(m => m.MachineType)
                .Include(m => m.City)
                .ThenInclude(m => m.Country)
                .ToListAsync();
        }

        public async Task<Machine> GetMachineById(Guid machineId)
        {
            return await _appDbContext.Machines
                .FirstOrDefaultAsync(m => m.Id.Equals(machineId));
        }

        public async Task<Machine> AddMachine(Machine machine)
        {
            var addedEntity = await _appDbContext.Machines.AddAsync(machine);
            await _appDbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<Machine> UpdateMachine(Machine machine)
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

        public async Task DeleteMachine(Guid machineId)
        {
            var foundMachine = await _appDbContext.Machines.FirstOrDefaultAsync(m => m.Id.Equals(machineId));

            if (foundMachine is null) return;

            _appDbContext.Machines.Remove(foundMachine);
            await _appDbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}