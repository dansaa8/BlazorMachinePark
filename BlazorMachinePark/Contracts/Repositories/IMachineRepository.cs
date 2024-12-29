using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Contracts.Repositories
{
    public interface IMachineRepository
    {
        Task<IEnumerable<Machine>> GetAllMachinesAsync();
        Task<Machine> GetMachineByIdAsync(Guid machineId);
        Task<Machine> AddMachineAsync(Machine machine);
        Task<Machine> UpdateMachineAsync(Machine machine);
        Task DeleteMachineAsync(Guid machineId);
        Task<int> CountMachinesAsync();
    }
}
