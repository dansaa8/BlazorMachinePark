using System.Text.Json;
using Blazored.LocalStorage;
using BlazorMachinePark.Client.Helper;
using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Shared.DTOs;
using BlazorMachinePark.Shared.Entities;

namespace BlazorMachinePark.Client
{
    public class ClientMachineService : IMachineService
    {
        private readonly HttpClient? _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public ClientMachineService(HttpClient? httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public Task<Machine> AddMachineAsync(Machine machine)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountMachinesAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteMachineAsync(Guid machineId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<MachineDto>> GetAllMachinesAsync()
        {
            // Check if the expiration key exists in local storage
            bool machineExpirationExists = await _localStorageService.ContainKeyAsync(LocalStorageConstants.MachineListExpirationKey);

            if (machineExpirationExists)
            {
                // Get the expiration time from local storage
                DateTime machineListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.MachineListExpirationKey);

                // If the expiration time is still valid, retrieve the machine list from local storage
                if (machineListExpiration > DateTime.Now)
                {
                    if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.MachineListKey))
                    {
                        return await _localStorageService.GetItemAsync<List<MachineDto>>(LocalStorageConstants.MachineListKey);
                    }
                }
            }

            // If expiration is invalid or data does not exist in local storage, fetch from API
            try
            {
                var list = await JsonSerializer.DeserializeAsync<IEnumerable<MachineDto>>(
                    await _httpClient.GetStreamAsync("/api/machine"),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                // Save the fetched list and expiration time to local storage
                await _localStorageService.SetItemAsync(LocalStorageConstants.MachineListKey, list);
                await _localStorageService.SetItemAsync(LocalStorageConstants.MachineListExpirationKey, DateTime.Now.AddMinutes(1));

                return list;
            }
            catch (Exception ex)
            {
                // Log error or handle exception as needed
                Console.Error.WriteLine($"Error fetching machines: {ex.Message}");
                return Enumerable.Empty<MachineDto>();
            }
        }


        public Task<Machine> GetMachineDetailsAsync(Guid machineId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMachineAsync(Machine machine)
        {
            throw new NotImplementedException();
        }
    }
}
