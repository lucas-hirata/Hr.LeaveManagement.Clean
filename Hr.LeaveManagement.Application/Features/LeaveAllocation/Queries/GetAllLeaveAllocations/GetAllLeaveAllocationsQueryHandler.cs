using AutoMapper;

using Hr.LeaveManagement.Application.Contracts.Logging;
using Hr.LeaveManagement.Application.Contracts.Persistence;

using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public class GetAllLeaveAllocationsQueryHandler : IRequestHandler<GetAllLeaveAllocationsQuery, IEnumerable<LeaveAllocationDto>>
{
    private readonly IApiLogger<GetAllLeaveAllocationsQueryHandler> _logger;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetAllLeaveAllocationsQueryHandler(
        IApiLogger<GetAllLeaveAllocationsQueryHandler> logger,
        ILeaveAllocationRepository leaveAllocationRepository,
        IMapper mapper)
    {
        _logger = logger;
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LeaveAllocationDto>> Handle(GetAllLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _leaveAllocationRepository.GetAsync();

        var data = _mapper.Map<IEnumerable<LeaveAllocationDto>>(leaveAllocations);

        return data;
    }
}
