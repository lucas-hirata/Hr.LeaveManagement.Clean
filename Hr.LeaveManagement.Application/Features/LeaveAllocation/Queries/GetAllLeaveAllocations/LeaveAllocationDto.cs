﻿using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public record LeaveAllocationDto
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}
