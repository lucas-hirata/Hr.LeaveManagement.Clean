using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public record CancelLeaveRequestCommand(int Id) : IRequest<Unit>;