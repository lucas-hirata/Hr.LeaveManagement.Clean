﻿using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public record LeaveAllocationDetailsDto
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public LeaveTypeDto? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}
