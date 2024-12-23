using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Contracts.Services
{
    public interface IMachineService
    {
        Task<IEnumerable<Machine>> GetAllMachines();
        Task<Machine> GetMachineDetails(Guid machineId);
        Task<Machine> AddMachine(Machine machine);
        Task UpdateMachine(Machine machine);
        Task DeleteMachine(Guid machineId);
    }
}
