using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Services;

public interface IMachineTypeService
{
    Task<IEnumerable<MachineType>> GetAllMachineTypes();
}