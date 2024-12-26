using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Contracts.Repositories;

public interface IMachineTypeRepository
{
    Task<IEnumerable<MachineType>> GetAllMachineTypes();
}