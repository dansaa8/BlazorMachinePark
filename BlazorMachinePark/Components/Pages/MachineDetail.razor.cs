using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Services.Services;
using BlazorMachinePark.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorMachinePark.Components.Pages;

public partial class MachineDetail
{
    [Parameter] public Guid MachineId { get; set; }

    [Inject] public IMachineService? MachineService { get; set; }
    [Inject] public MachineStateService? MachineStateService { get; set; }

    public Machine Machine { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Machine = await MachineService.GetMachineDetailsAsync(MachineId);
    }

    protected async Task ChangeRunningState()
    {
        Machine.IsRunning = !Machine.IsRunning;
        await MachineService.UpdateMachineAsync(Machine);
        
        // Notify that machine state has been updated:
        MachineStateService?.NotifyStateChanged();
    }
}