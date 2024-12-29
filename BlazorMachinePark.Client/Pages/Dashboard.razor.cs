using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace BlazorMachinePark.Client.Pages;

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