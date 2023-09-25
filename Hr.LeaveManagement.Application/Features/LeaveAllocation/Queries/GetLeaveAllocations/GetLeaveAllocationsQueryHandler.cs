using AutoMapper;

using Hr.LeaveManagement.Application.Contracts.Logging;
using Hr.LeaveManagement.Application.Contracts.Persistence;

using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, IEnumerable<LeaveAllocationDto>>
{
    private readonly IApiLogger<GetLeaveAllocationsQueryHandler> _logger;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationsQueryHandler(
        IApiLogger<GetLeaveAllocationsQueryHandler> logger,
        ILeaveAllocationRepository leaveAllocationRepository,
        IMapper mapper)
    {
        _logger = logger;
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocationRepository.GetAsync();

        var data = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

        return data;
    }
}
