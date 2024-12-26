using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Services;

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