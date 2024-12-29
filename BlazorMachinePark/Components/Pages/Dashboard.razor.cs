using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.DTOs;
using BlazorMachinePark.Shared.Domain;
using Microsoft.AspNetCore.Components;


namespace BlazorMachinePark.Components.Pages;

public partial class Dashboard 
{
    public List<MachineDto> Machines { get; set; } = default!;

    private string Title = "Dashboard";
    
    [Inject]
    public IMachineService? MachineService { get; set; }
    
    protected async override Task OnInitializedAsync()
    {
        Machines = (await MachineService.GetAllMachinesAsync()).ToList();
    }   
}