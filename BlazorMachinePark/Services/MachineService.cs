using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Data;
using BlazorMachinePark.DTOs;
using BlazorMachinePark.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorMachinePark.Services
{
    public class MachineService : IMachineService
    {
        public readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public async Task<IEnumerable<MachineDto>> GetAllMachines()
        {
            var machines = await _machineRepository.GetAllMachines();

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
                }
            }).ToList();
        }

        public async Task<Machine> GetMachineDetails(Guid machineId)
        {
            return await _machineRepository.GetMachineById(machineId);
        }

        public async Task<Machine> AddMachine(Machine machine)
        {
            return await _machineRepository.AddMachine(machine);
        }

        public async Task UpdateMachine(Machine machine)
        {
            await _machineRepository.UpdateMachine(machine);
        }

        public async Task DeleteMachine(Guid machineId)
        {
            await _machineRepository.DeleteMachine(machineId);
        }
    }
}