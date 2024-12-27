using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Services;
using BlazorMachinePark.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorMachinePark.Components.Pages;

public partial class MachineEdit : ComponentBase
{
    [Inject] public IMachineService? MachineService { get; set; }
    [Inject] public ICityService? CityService { get; set; }
    [Inject] public IMachineTypeService? MachineTypeService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Parameter] public Guid MachineId { get; set; }

    // används för att fånga inputed data, men också för att visa initial data.
    [SupplyParameterFromForm] public Machine Machine { get; set; } = new();

    public List<MachineType> MachineTypes { get; set; } = [];
    public List<City> Cities { get; set; } = [];

    protected bool Saved;

    protected string Message = string.Empty;
    protected string StatusClass = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        Saved = false;
        MachineTypes = (await MachineTypeService.GetAllMachineTypes()).ToList();
        Cities = (await CityService.GetAllCitiesAsync()).ToList();

        Machine = await MachineService.GetMachineDetails(MachineId);
    }

    protected async Task HandleValidSubmit()
    {
        await MachineService.UpdateMachine(Machine);
        Saved = true;
        StatusClass = "alert-success";
        Message = "Machine updated successfully";
    }

    protected async void HandleInvalidSubmit()
    {
        StatusClass = "alert-danger";
        Message = "There are some validation errors. Please try again.";
    }

    protected async Task DeleteMachine()
    {
        await MachineService.DeleteMachine(Machine.Id);

        StatusClass = "alert-success";
        Message = "Machine deleted successfully";
        Saved = true;
    }

    protected void NavigateToDashboard() => NavigationManager.NavigateTo("dashboard");
}