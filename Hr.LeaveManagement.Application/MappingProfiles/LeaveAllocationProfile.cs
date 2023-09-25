using AutoMapper;

using Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using Hr.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using Hr.LeaveManagement.Domain;

namespace Hr.LeaveManagement.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
    public LeaveAllocationProfile()
    {
        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        CreateMap<DeleteLeaveAllocationCommand, LeaveAllocation>();
    }
}
