using BlazorMachinePark.Shared.Entities;

namespace BlazorMachinePark.Contracts.Repositories;

public interface IMachineTypeRepository
{
    Task<IEnumerable<MachineType>> GetAllMachineTypes();
}