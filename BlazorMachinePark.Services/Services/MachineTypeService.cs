using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Shared.Entities;

namespace BlazorMachinePark.Services.Services;

public class MachineTypeService : IMachineTypeService
{
    private readonly IMachineTypeRepository _repository;

    public MachineTypeService(IMachineTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MachineType>> GetAllMachineTypes()
    {
        return await _repository.GetAllMachineTypes();
    }
}