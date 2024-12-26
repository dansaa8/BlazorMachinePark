using BlazorMachinePark.Shared.Domain;

namespace BlazorMachinePark.Contracts.Repositories;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllCities();

}