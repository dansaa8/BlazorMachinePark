using BlazorMachinePark.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorMachinePark.Components.Pages;

public partial class MachineCard 
{
    [Parameter]
    public Machine Machine { get; set; }
    
    // [Parameter]
}