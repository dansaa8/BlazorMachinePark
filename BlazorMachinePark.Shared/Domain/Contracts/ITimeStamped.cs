namespace BlazorMachinePark.Shared.Domain.Contracts;

public interface ITimeStamped
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}