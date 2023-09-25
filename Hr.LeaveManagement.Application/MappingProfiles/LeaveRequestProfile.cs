using AutoMapper;
using Hr.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using Hr.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using Hr.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using Hr.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
using Hr.LeaveManagement.Domain;

namespace Hr.LeaveManagement.Application.MappingProfiles;

public class LeaveRequestProfile : Profile
{
    public LeaveRequestProfile()
    {
        CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
        CreateMap<LeaveRequestDetailsDto, LeaveRequest>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
        CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
        CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
    }
}
