using BlazorMachinePark.Contracts.Repositories;
using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Shared.Entities;

namespace BlazorMachinePark.Services.Services;

public class CityService : ICityService
{
    public readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<IEnumerable<City>> GetAllCitiesAsync()
    {
        return await _cityRepository.GetAllCities();
    }
}