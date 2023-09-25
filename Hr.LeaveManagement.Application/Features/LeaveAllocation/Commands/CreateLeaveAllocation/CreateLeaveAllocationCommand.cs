using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public record CreateLeaveAllocationCommand : IRequest<int>
{
    public int LeaveTypeId { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}
