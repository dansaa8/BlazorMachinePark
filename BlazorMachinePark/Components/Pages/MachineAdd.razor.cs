using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMachinePark.Components.Pages;

public partial class MachineAdd
{
    [SupplyParameterFromForm] public Machine Machine { get; set; }
    public List<MachineType> MachineTypes { get; set; } = new();
    public List<City> Cities { get; set; } = new();

    [Inject] public IMachineService? MachineService { get; set; }
    [Inject] public ICityService? CityService { get; set; }
    [Inject] public IMachineTypeService? MachineTypeService { get; set; }

    protected string Message = string.Empty;
    protected bool IsSubmitted = false;

    protected override async Task OnInitializedAsync()
    {
        Machine ??= new Machine();
        Cities = (await CityService.GetAllCitiesAsync()).ToList();
        MachineTypes = (await MachineTypeService.GetAllMachineTypes()).ToList();
        Console.WriteLine("Loaded Cities:");
        foreach (var city in Cities)
        {
            Console.WriteLine($"Id: {city.Id}, Name: {city.Name}, Country: {city.Country?.Name}");
        }

        Console.WriteLine("Loaded Machine Types:");
        foreach (var machineType in MachineTypes)
        {
            Console.WriteLine($"Id: {machineType.Id}, Name: {machineType.Name}, Description: {machineType.Description}");
        }
    }

    private async Task OnSubmit()
    {
        Console.WriteLine($"CityId: {Machine.CityId}");
        Console.WriteLine($"MachineTypeId: {Machine.MachineTypeId}");
        await MachineService.AddMachineAsync(Machine);
        IsSubmitted = true;
        Message = "Machine added";
    }
}