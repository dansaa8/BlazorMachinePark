using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Contracts.Services;

public interface ICityService
{
    Task<IEnumerable<City>> GetAllCitiesAsync();
}