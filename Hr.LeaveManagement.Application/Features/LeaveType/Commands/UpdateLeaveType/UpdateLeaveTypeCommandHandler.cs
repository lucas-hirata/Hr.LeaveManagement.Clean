using AutoMapper;

using Hr.LeaveManagement.Application.Contracts.Logging;
using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Application.Exceptions;
using Hr.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IApiLogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(
        IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        IApiLogger<UpdateLeaveTypeCommandHandler> logger)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new UpdateLeaveTypeCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
            throw new BadRequestException("Invalid leave type", validationResult);
        }

        // Convert to domain entity object
        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

        // Add to database
        await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

        // Return Unit value
        return Unit.Value;
    }
}
