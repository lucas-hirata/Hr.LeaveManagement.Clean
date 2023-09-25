using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public record ChangeLeaveRequestApprovalCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public bool Approved { get; set; }
}