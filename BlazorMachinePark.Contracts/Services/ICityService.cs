using BlazorMachinePark.Shared.Entities;

namespace BlazorMachinePark.Contracts.Services;

public interface ICityService
{
    Task<IEnumerable<City>> GetAllCitiesAsync();
}