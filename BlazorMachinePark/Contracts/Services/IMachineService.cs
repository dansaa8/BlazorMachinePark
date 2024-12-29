using BlazorMachinePark.DTOs;
using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Contracts.Services
{
    public interface IMachineService
    {
        Task<IEnumerable<MachineDto>> GetAllMachinesAsync();
        Task<Machine> GetMachineDetailsAsync(Guid machineId);
        Task<Machine> AddMachineAsync(Machine machine);
        Task UpdateMachineAsync(Machine machine);
        Task DeleteMachineAsync(Guid machineId);
        Task<int> CountMachinesAsync();
    }
}