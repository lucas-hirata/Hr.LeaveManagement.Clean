using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public record DeleteLeaveAllocationCommand(int Id) : IRequest<Unit> ;