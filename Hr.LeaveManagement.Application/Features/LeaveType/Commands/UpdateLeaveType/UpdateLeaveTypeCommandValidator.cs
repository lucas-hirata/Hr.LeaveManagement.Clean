using FluentValidation;

using Hr.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    public UpdateLeaveTypeCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName must be fewer than 70 characters}");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1")
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100");
    }
}
