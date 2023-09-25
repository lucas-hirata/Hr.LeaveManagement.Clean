using AutoMapper;

using Hr.LeaveManagement.Application.Contracts.Logging;
using Hr.LeaveManagement.Application.Contracts.Persistence;

using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IApiLogger<GetLeaveAllocationDetailsQueryHandler> _logger;

    public GetLeaveAllocationDetailsQueryHandler(
        IMapper mapper,
        ILeaveAllocationRepository leaveAllocationRepository,
        IApiLogger<GetLeaveAllocationDetailsQueryHandler> logger)
    {
        this._mapper = mapper;
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._logger = logger;
    }

    public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocationDetails = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

        var data = _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocationDetails);

        return data;
    }
}
