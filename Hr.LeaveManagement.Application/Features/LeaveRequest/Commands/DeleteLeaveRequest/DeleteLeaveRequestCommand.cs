using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public record DeleteLeaveRequestCommand(int Id) : IRequest<Unit>;