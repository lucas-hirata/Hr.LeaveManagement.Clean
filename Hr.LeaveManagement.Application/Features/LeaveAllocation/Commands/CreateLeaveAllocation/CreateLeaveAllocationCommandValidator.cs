using FluentValidation;

using Hr.LeaveManagement.Application.Contracts.Persistence;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;

        RuleFor(q => q.NumberOfDays)
            .NotEmpty().WithMessage("Number Of Days must be greater than 0");

        RuleFor(q => q.LeaveTypeId)
            .NotEmpty().WithMessage("Leave Type Id must be valid")
            .MustAsync(LeaveTypeExists);

        RuleFor(q => q.Period)
            .NotEmpty().WithMessage("Period must be greater than 0");

        RuleFor(q => q.EmployeeId)
            .NotEmpty().WithMessage("Employee Id must be greater than 0");
    }

    private Task<bool> LeaveTypeExists(int id, CancellationToken cancellationToken)
    {
        return _leaveTypeRepository.Exists(id);
    }
}
