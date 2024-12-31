using BlazorMachinePark.Contracts.Services;
using BlazorMachinePark.Services.Services;
using BlazorMachinePark.Shared.Entities;
using BlazorMachinePark.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorMachinePark.Components.Pages;

public partial class MachineDetail
{
    [Parameter] public Guid MachineId { get; set; }

    [Inject] public IMachineService? MachineService { get; set; }

    public Machine Machine { get; set; } = null!;

    public List<Marker> MapMarkers { get; set; } = new List<Marker>();

    protected override async Task OnInitializedAsync()
    {
        Machine = await MachineService.GetMachineDetailsAsync(MachineId);

        if (Machine.Longitude.HasValue && Machine.Latitude.HasValue)
        {
            MapMarkers = new List<Marker>
            {
                new Marker{Description = $"{Machine.Id}", ShowPopup = false,
                X = Machine.Longitude.Value, Y = Machine.Latitude.Value}
            };
        }
    }

    protected async Task ChangeRunningState()
    {
        Machine.IsRunning = !Machine.IsRunning;
        await MachineService.UpdateMachineAsync(Machine);
    }
}