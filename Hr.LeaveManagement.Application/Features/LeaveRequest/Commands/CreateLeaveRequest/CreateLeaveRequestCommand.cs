using Hr.LeaveManagement.Application.Features.LeaveRequest.Shared;

using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public record CreateLeaveRequestCommand(string RequestComments = "") : BaseLeaveRequest, IRequest<Unit>;