using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public record DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;
