namespace BlazorMachinePark.Shared.DTOs;

public class MachineDto
{
    public Guid Id { get; set; }
    public bool IsRunning { get; set; }
    public LocationDto Location { get; set; } // Nested Location DTO
    public MachineTypeDto MachineType { get; set; } // Nested Machine Type DTO
    
    public DateTime UpdatedAt { get; set; }
}