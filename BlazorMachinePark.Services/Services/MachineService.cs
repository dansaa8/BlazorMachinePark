using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Shared.DTOs;
using BlazorMachinePark.Shared.Entities;

namespace BlazorMachinePark.Services.Services
{
    public class MachineService : IMachineService
    {
        public readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public async Task<IEnumerable<MachineDto>> GetAllMachinesAsync()
        {
            var machines = await _machineRepository.GetAllMachinesAsync();

            return machines.Select(m => new MachineDto
            {
                Id = m.Id,
                IsRunning = m.IsRunning,
                Location = new LocationDto
                {
                    CityName = m.City?.Name,
                    CountryName = m.City?.Country?.Name,
                    CountryFlag = m.City?.Country?.EmojiFlag
                },
                MachineType = new MachineTypeDto
                {
                    Name = m.MachineType.Name,
                    Description = m.MachineType.Description
                },
                UpdatedAt = m.UpdatedAt
            }).ToList();
        }

        public async Task<Machine> GetMachineDetailsAsync(Guid machineId)
        {
            return await _machineRepository.GetMachineByIdAsync(machineId);
        }

        public async Task<Machine> AddMachineAsync(Machine machine)
        {
            return await _machineRepository.AddMachineAsync(machine);
        }

        public async Task UpdateMachineAsync(Machine machine)
        {
            await _machineRepository.UpdateMachineAsync(machine);
        }

        public async Task DeleteMachineAsync(Guid machineId)
        {
            await _machineRepository.DeleteMachineAsync(machineId);
        }

        public Task<int> CountMachinesAsync()
        {
            return _machineRepository.CountMachinesAsync();
        }
    }
}