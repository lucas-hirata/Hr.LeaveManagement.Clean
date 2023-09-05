using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record GetAllLeaveTypesQuery : IRequest<IEnumerable<LeaveTypeDto>>;
