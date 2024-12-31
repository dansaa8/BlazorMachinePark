using BlazorMachinePark.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorMachinePark.Components;

public partial class Map
{
    string elementId = $"map-{Guid.NewGuid():D}";

    [Parameter] public double Zoom { get; set; }

    [Parameter] public List<Marker> Markers { get; set; }

    [Inject] IJSRuntime JsRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JsRuntime.InvokeVoidAsync(
            "deliveryMap.showOrUpdate",
            elementId,
            Markers);
    }
}