using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public record GetLeaveAllocationsQuery : IRequest<IEnumerable<LeaveAllocationDto>>;
