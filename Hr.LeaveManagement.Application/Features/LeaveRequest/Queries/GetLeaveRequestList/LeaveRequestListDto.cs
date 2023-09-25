using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace Hr.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;

public record LeaveRequestListDto
{
    public string RequestingEmployeeId { get; set; } = string.Empty;
    public LeaveTypeDto? LeaveType { get; set; }
    public DateTime DateRequested { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool? Approved { get; set; }
}