using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;

public record GetLeaveRequestDetailQuery(int Id) : IRequest<LeaveRequestDetailsDto>;