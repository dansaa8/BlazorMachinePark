using BlazorMachinePark.Shared.Entities;

namespace BlazorMachinePark.Contracts.Services;

public interface IMachineTypeService
{
    Task<IEnumerable<MachineType>> GetAllMachineTypes();
}