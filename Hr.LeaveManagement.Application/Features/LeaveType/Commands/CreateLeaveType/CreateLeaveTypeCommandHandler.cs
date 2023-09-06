﻿using AutoMapper;
using Hr.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // TODO: Validate incoming data

        // Convert to domain entity object
        var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

        // Add to database
        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

        // Return record id
        return leaveTypeToCreate.Id;
    }
}
