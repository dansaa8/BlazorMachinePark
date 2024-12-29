using BlazorMachinePark.Shared.DTOs;
using BlazorMachinePark.Shared.Entities;

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