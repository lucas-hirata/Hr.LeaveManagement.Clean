﻿using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public record UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
