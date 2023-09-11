using AutoMapper;

using Hr.LeaveManagement.Application.Contracts.Logging;
using Hr.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, IEnumerable<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IApiLogger<GetAllLeaveTypesQueryHandler> _logger;

    public GetAllLeaveTypesQueryHandler(
        IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        IApiLogger<GetAllLeaveTypesQueryHandler> logger)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<IEnumerable<LeaveTypeDto>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        // query database
        var leaveTypes = (await _leaveTypeRepository.GetAsync());

        // convert to dto
        var data = _mapper.Map<IEnumerable<LeaveTypeDto>>(leaveTypes);

        // return list of dtos
        _logger.LogInformation("Leave types were retrieved successfully");
        return data;
    }
}
