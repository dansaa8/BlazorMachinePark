using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Contracts.Repositories
{
    public interface IMachineRepository
    {
        Task<IEnumerable<Machine>> GetAllMachines();
        Task<Machine> GetMachineById(Guid machineId);
        Task<Machine> AddMachine(Machine machine);
        Task<Machine> UpdateMachine(Machine machine);
        Task DeleteMachine(Guid machineId);
    }
}
