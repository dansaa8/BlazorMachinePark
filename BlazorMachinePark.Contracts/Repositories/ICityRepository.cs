using BlazorMachinePark.Shared.Entities;

namespace BlazorMachinePark.Contracts.Repositories;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllCities();

}