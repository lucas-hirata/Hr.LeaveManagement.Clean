using FluentValidation;

using Hr.LeaveManagement.Application.Contracts.Persistence;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveAllocationCommandValidator(
        ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository)
    {
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._leaveTypeRepository = leaveTypeRepository;

        RuleFor(q => q.Id)
            .NotEmpty()
            .MustAsync(LeaveAllocationExists)
            .WithMessage("Leave Allocation Id must be valid");

        RuleFor(q => q.NumberOfDays)
            .NotEmpty().WithMessage("Number Of Days must be greater than 0");

        RuleFor(q => q.LeaveTypeId)
            .NotEmpty()
            .MustAsync(LeaveTypeExists)
            .WithMessage("Leave Type Id must be valid");

        RuleFor(q => q.Period)
            .NotEmpty().WithMessage("Period must be greater than 0");
    }

    private Task<bool> LeaveAllocationExists(int id, CancellationToken cancellationToken)
    {
        return _leaveAllocationRepository.Exists(id);
    }

    private Task<bool> LeaveTypeExists(int id, CancellationToken cancellationToken)
    {
        return _leaveTypeRepository.Exists(id);
    }
}
